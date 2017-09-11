using ProPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Jallikattu
{
    public class PowerUpGenerator : MonoBehaviour
    {
        private Settings _settings;
        private float _timeSinceLastSpawn;
        private bool _init;

        private void Update()
        {
            if (!_init) return;

            if (_timeSinceLastSpawn > _settings.spawnDelay)
            {
                GeneratePowerup();
                _timeSinceLastSpawn = 0;
            }

            _timeSinceLastSpawn += Time.deltaTime;
        }

        public void Init(Settings settings)
        {
            _settings = settings;

            Reset();
            _init = true;
        }

        public void GeneratePowerup()
        {
            GameObject prefab = GetNewRandomPowerup();
            Vector3 spawnPosition = transform.position;
            GameObject go = PoolManager.Instance.GetPool(prefab).GetFromPool(spawnPosition, Quaternion.identity, _settings.holder.transform);
        }

        GameObject GetNewRandomPowerup()
        {
            int index = Random.Range(0, _settings.prefabs.Length);
            return _settings.prefabs[index];
        }

        public void Reset()
        {
            _timeSinceLastSpawn = 0;
        }

        [System.Serializable]
        public class Settings
        {
            public GameObject[] prefabs;
            public float spawnDelay;
            public GameObject holder;
        }
    }
}

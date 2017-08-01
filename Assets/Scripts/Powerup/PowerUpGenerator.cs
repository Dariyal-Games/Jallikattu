using ProPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Jallikattu {
    public class PowerUpGenerator : MonoBehaviour
    {
        private Settings _settings;
        private float _timeSinceLastSpawn;

        private void Update()
        {
            if (_timeSinceLastSpawn > _settings.spawnDelay)
            {
                GeneratePowerup();
            }
        }

        public void Init(Settings settings)
        {
            _settings = settings;

            Reset();
        }

        public void GeneratePowerup()
        {
            GameObject prefab = GetNewRandomPowerup();

            GameObject go = PoolManager.Instance.GetPool(prefab).GetFromPool(transform.position, Quaternion.identity, _settings.holder.transform);
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

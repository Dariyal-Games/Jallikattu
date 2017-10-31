using ProPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Jallikattu
{
    public class PowerUpGenerator : MonoBehaviour
    {
        private Settings _settings;
        private float _timeSinceLastSpawn, _timeSinceLastSpawnOfBooster;
        private bool _init;

        private void Update()
        {
            if (!_init) return;

            if (_timeSinceLastSpawn > _settings.spawnDelay)
            {
                GeneratePowerup();
                _timeSinceLastSpawn = 0;
            }

            if (_timeSinceLastSpawnOfBooster > _settings.spawnDelayOfBooster)
            {
                GenerateBooster();
                _timeSinceLastSpawnOfBooster = 0;
            }

            _timeSinceLastSpawn += Time.deltaTime;
            _timeSinceLastSpawnOfBooster += Time.deltaTime;
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

        public void GenerateBooster()
        {
            GameObject booster = GetNewRandomBooster();
            Vector3 spawnPosition =  new Vector3(transform.position.x - Random.Range(-1, 1), transform.position.y, transform.position.z - Random.Range(-0.5f, 0.5f));
            GameObject go = PoolManager.Instance.GetPool(booster).GetFromPool(spawnPosition, Quaternion.identity, _settings.holder.transform);
        }

        GameObject GetNewRandomPowerup()
        {
            int index = Random.Range(0, _settings.prefabs.Length);
            return _settings.prefabs[index];
        }

        GameObject GetNewRandomBooster()
        {
            int index2 = Random.Range(0, _settings.boosters.Length);
            return _settings.boosters[index2];
        }

        public void Reset()
        {
            _timeSinceLastSpawn = 0;
        }

        [System.Serializable]
        public class Settings
        {
            public GameObject[] prefabs, boosters;
            public float spawnDelay, spawnDelayOfBooster;
            public GameObject holder;
        }
    }
}

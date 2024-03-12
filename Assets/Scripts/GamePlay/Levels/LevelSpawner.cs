using System.Collections.Generic;
using UnityEngine;

internal class LevelSpawner : MonoBehaviour
{
    private readonly float _randomSpawnFactor = 10f;
    private readonly float _maxAngleY = 359f;
    private readonly float _minAngleX = 85f;
    private readonly float _maxAngleX = 95f;

    [SerializeField] private SpawnZone _spawnZone;    
    [SerializeField] private List<Scrap> _scraps;

    private float _targetWeight;

    private float _scrapCollectorLevel;

    private void Awake() => _scrapCollectorLevel = PlayerPrefs.GetFloat(GameSaver.ScrapCollector);

    public void Initialize(float targetWeight) => _targetWeight = targetWeight;

    public void StartSpawn() => SpawnScraps();
   
    private void SpawnScraps()
    {
        float currentSpawnWeight = 0;
        float randomSpawnFactor = Random.Range(0, _randomSpawnFactor);

        while (currentSpawnWeight < _targetWeight + randomSpawnFactor)
        {
            foreach (var scrap in _scraps)
            {
                Spawn(scrap);

                if (scrap.Info.Rank <= _scrapCollectorLevel)
                    currentSpawnWeight += scrap.Info.Weight;
            }
        }
    }

    private void Spawn(Scrap scrap)
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(Random.Range(_minAngleX, _maxAngleX), Random.Range(0, _maxAngleY), 0));
        Instantiate(scrap, _spawnZone.GetRandomPointInZone(), rotation);
    }
}

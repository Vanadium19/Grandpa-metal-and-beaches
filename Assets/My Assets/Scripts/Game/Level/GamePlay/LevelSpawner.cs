using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class LevelSpawner : MonoBehaviour
{
    private readonly int _uncollectableScrapSpawnFactor = 5;
    private readonly float _randomSpawnFactor = 10f;
    private readonly float _maxAngleY = 359f;
    private readonly float _angleXFactor = 5f;

    [SerializeField] private SpawnZone _spawnZone;
    [SerializeField] private List<Scrap> _scraps;

    private float _targetWeight;
    private float _scrapCollectorLevel;

    private void Awake() => _scrapCollectorLevel = PlayerPrefs.GetFloat(GameSaverData.ScrapCollector);

    public void Initialize(float targetWeight) => _targetWeight = targetWeight;

    public void StartSpawn() => SpawnScraps();

    private void SpawnScraps()
    {
        var scraps = _scraps.Where(scrap => scrap.Info.Rank <= _scrapCollectorLevel).ToList();
        SpawnCollectableScrap(scraps);

        scraps = _scraps.Where(scrap => scrap.Info.Rank > _scrapCollectorLevel).ToList();
        SpawnUncollectableScrap(scraps);
    }

    private void SpawnCollectableScrap(List<Scrap> scraps)
    {
        if (scraps == null)
            return;

        float currentSpawnWeight = 0;
        float targetWeight = _targetWeight + Random.Range(0, _randomSpawnFactor);

        while (currentSpawnWeight < targetWeight)
        {
            foreach (var scrap in scraps)
            {
                Spawn(scrap);
                currentSpawnWeight += scrap.Info.Weight;
            }
        }
    }

    private void SpawnUncollectableScrap(List<Scrap> scraps)
    {
        if (scraps == null)
            return;

        for (int i = 0; i < _uncollectableScrapSpawnFactor; i++)
        {
            foreach (var scrap in scraps)
            {
                Spawn(scrap);
            }
        }
    }

    private void Spawn(Scrap scrap)
    {
        float angleX = Random.Range(scrap.RotationAngleX - _angleXFactor, scrap.RotationAngleX + _angleXFactor);
        float angleY = Random.Range(0, _maxAngleY);

        Quaternion rotation = Quaternion.Euler(new Vector3(angleX, angleY, 0));
        Instantiate(scrap, _spawnZone.GetRandomPointInZone(), rotation);
    }
}

using System.Collections.Generic;
using UnityEngine;

internal class LevelSpawner : MonoBehaviour
{
    private readonly float _randomSpawnFactor = 10f;
    private readonly float _maxAngleY = 359f;
    private readonly float _angleXFactor = 5f;

    [SerializeField] private SpawnZone _spawnZone;    
    [SerializeField] private List<Scrap> _scraps;

    private float _targetWeight;

    public void Initialize(float targetWeight) => _targetWeight = targetWeight;

    public void StartSpawn() => SpawnScraps();
   
    private void SpawnScraps()
    {
        float currentSpawnWeight = 0;
        float randomSpawnFactor = Random.Range(0, _randomSpawnFactor);

        while (currentSpawnWeight < _targetWeight + randomSpawnFactor)
        {
            foreach (var scrap in _scraps)            
                Spawn(scrap, ref currentSpawnWeight);            
        }
    }

    private void Spawn(Scrap scrap, ref float currentSpawnWeight)
    {
        float angleX = Random.Range(scrap.RotationAngleX - _angleXFactor, scrap.RotationAngleX + _angleXFactor);
        float angleY = Random.Range(0, _maxAngleY);

        Quaternion rotation = Quaternion.Euler(new Vector3(angleX, angleY, 0));
        Instantiate(scrap, _spawnZone.GetRandomPointInZone(), rotation);

        currentSpawnWeight += scrap.Info.Weight;
    }
}

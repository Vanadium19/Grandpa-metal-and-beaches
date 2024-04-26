using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    private float _capacity;
    private List<Scrap> _content = new List<Scrap>();

    public event Action<float> ContentChanged;

    public float Capacity => _capacity;
    private float CurrentWeight => _content.Sum(content => content.Info.Weight);

    private void Awake() => _capacity = PlayerPrefs.GetFloat(GameSaverData.Bag);

    private void OnEnable() => _playerStats.PlayerUpgraded += ChangeCapacity;

    private void Start() => ContentChanged?.Invoke(_content.Count);

    private void OnDisable() => _playerStats.PlayerUpgraded -= ChangeCapacity;

    public bool CanAdd(Scrap scrap) => CurrentWeight + scrap.Info.Weight <= _capacity;

    public void Add(Scrap scrap)
    {
        _content.Add(scrap);
        ContentChanged?.Invoke(CurrentWeight);
    }

    public void Remove(Scrap scrap)
    {
        _content.Remove(scrap);
        ContentChanged?.Invoke(CurrentWeight);
    }

    private void ChangeCapacity(float capacity)
    {
        _capacity = capacity;
        ContentChanged?.Invoke(CurrentWeight);
    }
}

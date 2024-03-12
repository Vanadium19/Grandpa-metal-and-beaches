using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System.Linq;

public class Bag : MonoBehaviour
{
    [SerializeField] private UpgradePanel _upgradePanel;

    private float _capacity;
    private List<Scrap> _content = new List<Scrap>();

    public event UnityAction<float> ContentChanged;

    public float Capacity => _capacity;
    private float _currentWeight => _content.Sum(content => content.Info.Weight);

    private void Awake() => _capacity = PlayerPrefs.GetFloat(GameSaver.Bag);

    private void OnEnable() => _upgradePanel.PlayerUpgraded += ChangeCapacity;

    private void Start() => ContentChanged?.Invoke(_content.Count);

    private void OnDisable() => _upgradePanel.PlayerUpgraded -= ChangeCapacity;

    public bool CanAdd(Scrap scrap) => _currentWeight + scrap.Info.Weight <= _capacity;

    public void Add(Scrap scrap)
    {
        _content.Add(scrap);
        ContentChanged?.Invoke(_currentWeight);
    }

    public void Remove(Scrap scrap)
    {
        _content.Remove(scrap);
        ContentChanged?.Invoke(_currentWeight);
    }

    private void ChangeCapacity()
    {
        _capacity = PlayerPrefs.GetFloat(GameSaver.Bag);
        ContentChanged?.Invoke(_currentWeight);
    }   
}

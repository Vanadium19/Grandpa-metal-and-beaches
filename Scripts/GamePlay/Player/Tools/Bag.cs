using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System.Linq;

public class Bag : MonoBehaviour
{
    private float _capacity;
    private List<Scrap> _content = new List<Scrap>();

    public event UnityAction<float> ContentChanged;

    public float Capacity => _capacity;
    private float _currentWeight => _content.Sum(content => content.Info.Weight);
    private float _currentMoney => _content.Sum(content => content.Info.Price);

    private void Awake() => _capacity = PlayerPrefs.GetFloat(GameSaver.Bag);

    private void Start() => ContentChanged?.Invoke(_content.Count);

    public bool CanAdd(Scrap scrap) => _currentWeight + scrap.Info.Weight <= _capacity;

    public void Add(Scrap scrap)
    {
        _content.Add(scrap);
        ContentChanged?.Invoke(_currentWeight);
    }

    public bool TryGet(out float weight, out float money)
    {
        weight = _currentWeight;
        money = _currentMoney;

        _content.Clear();
        ContentChanged?.Invoke(_content.Count);

        return weight != 0;
    }
}

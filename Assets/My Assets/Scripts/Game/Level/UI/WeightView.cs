using TMPro;
using UnityEngine;

public class WeightView : MonoBehaviour
{
    [SerializeField] private Dumpster _dumpster;
    [SerializeField] private TMP_Text _weight;
    
    private float _targetWeight;
    private float _currentWeight;

    private void OnEnable() => _dumpster.ScrapCollected += AddWeight;

    private void OnDisable() => _dumpster.ScrapCollected -= AddWeight;

    public void Initialize(float targetWeight, float currentWeight)
    {
        _targetWeight = targetWeight;
        _currentWeight = currentWeight;
        UpdateDisplay();
    }
    private void AddWeight(Scrap scrap)
    {
        _currentWeight += scrap.Info.Weight;
        UpdateDisplay();
    }

    private void UpdateDisplay() => _weight.text = $"{_currentWeight}/{_targetWeight}";
}
        





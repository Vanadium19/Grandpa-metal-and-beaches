using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Dumpster _dumpster;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

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

    private void UpdateDisplay()
    {
        _slider.value = _currentWeight / _targetWeight;
        _text.text = $"{_currentWeight}/{_targetWeight}";
    }
}
        





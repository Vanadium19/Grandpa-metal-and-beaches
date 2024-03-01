using TMPro;
using UnityEngine;

public class LevelGoalsView : DumpsterObserver
{
    [SerializeField] private TMP_Text _weight;
    [SerializeField] private TMP_Text _money;

    protected override void UpdateProgress(float currentWeight, float currentMoney)
    {
        _weight.text = $"{currentWeight}/{TargetWeight}";
        _money.text = $"{currentMoney}/{TargetMoney}";
    }
}

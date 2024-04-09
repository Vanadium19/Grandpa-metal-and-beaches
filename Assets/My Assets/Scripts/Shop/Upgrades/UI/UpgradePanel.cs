using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _closingPanels;

    public event UnityAction PlayerUpgraded;

    private void OnEnable() => TurnOnClosingMenus(false);

    private void OnDisable()
    {
        TurnOnClosingMenus(true);

        PlayerUpgraded?.Invoke();
    }

    private void TurnOnClosingMenus(bool value)
    {
        foreach (var closingMenu in _closingPanels)
            closingMenu.SetActive(value);
    }
}

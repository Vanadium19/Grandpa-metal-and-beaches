using System;
using UnityEngine;

internal class Tutorial : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Menu _menu;
    [SerializeField] private GameObject _tutorialPanel;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(GameSaverData.Tutorial + _name))
            TurnOnTutorial();
        
        enabled = false;
    }

    private void TurnOnTutorial()
    {
        _tutorialPanel.SetActive(true);
        _menu.StopTime();

        PlayerPrefs.SetInt(GameSaverData.Tutorial + _name, Convert.ToInt16(true));
        PlayerPrefs.Save();
    }
}

using System;
using UnityEngine;

internal class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialPanel;

    private int _tutorialSavingParam;
    private bool _isTrained;

    private void Awake()
    {
        _tutorialSavingParam = PlayerPrefs.GetInt(GameSaver.Tutorial);
        _isTrained = Convert.ToBoolean(_tutorialSavingParam);
    }

    private void Start()
    {
        SwitchTutorial();
        enabled = false;
    }

    private void SwitchTutorial()
    {
        _tutorialPanel.SetActive(!_isTrained);
        Time.timeScale = _tutorialSavingParam;
    }
}

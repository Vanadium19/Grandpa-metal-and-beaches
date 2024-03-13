using System;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialPanel;
    private bool _isTrained;

    private void Awake() => _isTrained = Convert.ToBoolean(PlayerPrefs.GetInt(GameSaver.Tutorial));

    private void Start()
    {
        _tutorialPanel.SetActive(!_isTrained);
        enabled = false;
    }
}

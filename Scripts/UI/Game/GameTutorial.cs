using System;
using UnityEngine;

internal class GameTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialPanel;

    private void Start() => TurnOn(Convert.ToBoolean(PlayerPrefs.GetInt(GameSaver.Tutorial)) == false);

    private void TurnOn(bool value)
    {
        _tutorialPanel.SetActive(value);
        gameObject.SetActive(value);

        if (value)
            PlayerPrefs.SetInt(GameSaver.Tutorial, Convert.ToInt16(value));
    }
}

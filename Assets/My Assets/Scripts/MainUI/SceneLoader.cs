using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    private readonly float _percentFactor = 100f;

    [Tooltip("0 - StartMenu, 1 - Game, 2 - Hub")]
    [SerializeField] private int _sceneNumber;

    [SerializeField] private GameObject _loadPanel;
    [SerializeField] private TMP_Text _percent;

    public void Load()
    {
        _loadPanel.SetActive(true);
        StartCoroutine(StartLoad());
    }

    private IEnumerator StartLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneNumber);

        while (asyncLoad.isDone == false)
        {
            _percent.text = $"{Mathf.Round(asyncLoad.progress * _percentFactor)}%";
            yield return null;
        }
    }
}

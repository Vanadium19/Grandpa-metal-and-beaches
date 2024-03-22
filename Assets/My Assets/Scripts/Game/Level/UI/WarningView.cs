using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
internal class WarningView : MonoBehaviour
{
    [Tooltip("0 - BagCrowded, 1 - OutOfLevel, 2 - Water")]
    [SerializeField] private GameObject[] _alerts;
    [SerializeField] private Water _water;
    [SerializeField] private ScrapCollector _scrapCollector;

    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void OnEnable()
    {
        _scrapCollector.Alarmed += Set;
        _water.PlayerEntered += Set;
        _water.PlayerLeft += Close;
    }

    private void OnDisable()
    {
        _scrapCollector.Alarmed -= Set;
        _water.PlayerEntered -= Set;
        _water.PlayerLeft -= Close;
    }

    private void Set(WarningNames.Alerts alert)
    {
        for (int i = 0; i < _alerts.Length; i++)
            _alerts[i].SetActive(i == (int)alert);

        _audioSource.Play();
    }

    private void Close(WarningNames.Alerts alert)
    {
        if ((int)alert >= 0 && (int)alert < _alerts.Length)
            _alerts[(int)alert].SetActive(false);        
    }
}

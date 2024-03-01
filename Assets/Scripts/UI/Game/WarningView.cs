using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WarningView : MonoBehaviour
{
    [Tooltip("0 - BagCrowded, 1 - OutOfLevel, 2 - Water")]
    [SerializeField] private GameObject[] _alerts;

    [SerializeField] private ScrapCollector _scrapCollector;

    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void OnEnable() => _scrapCollector.Alarmed += Set;

    private void OnDisable() => _scrapCollector.Alarmed -= Set;

    public void Set(WarningNames.Alerts alert)
    {
        for (int i = 0; i < _alerts.Length; i++)
            _alerts[i].SetActive(i == (int)alert);

        _audioSource.Play();
    }

    public void Close(WarningNames.Alerts alert)
    {
        if ((int)alert >= 0 && (int)alert < _alerts.Length)
            _alerts[(int)alert].SetActive(false);        
    }
}

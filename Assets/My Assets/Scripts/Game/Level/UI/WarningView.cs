using UnityEngine;

internal class WarningView : MonoBehaviour
{
    [Tooltip("0 - BagCrowded, 1 - OutOfLevel")]
    [SerializeField] private GameObject[] _alerts;
    [SerializeField] private ScrapCollector _scrapCollector;

    private void OnEnable() => _scrapCollector.Alarmed += Set;

    private void OnDisable() => _scrapCollector.Alarmed -= Set;

    private void Set(ScrapCollector.Alerts alert)
    {
        for (int i = 0; i < _alerts.Length; i++)
            _alerts[i].SetActive(i == (int)alert);
    }
}

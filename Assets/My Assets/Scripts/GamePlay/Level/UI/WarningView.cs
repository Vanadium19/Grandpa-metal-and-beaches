using GMB.GamePlay.PlayerEnvironment;
using GMB.StaticData;
using UnityEngine;

namespace GMB.GamePlay.Level.UI
{
    internal class WarningView : MonoBehaviour
    {
        [Tooltip("0 - BagCrowded, 1 - OutOfLevel")]
        [SerializeField] private GameObject[] _alerts;
        [SerializeField] private ScrapCollector _scrapCollector;

        private void OnEnable()
        {
            _scrapCollector.Alarmed += Set;
        }

        private void OnDisable()
        {
            _scrapCollector.Alarmed -= Set;
        }

        private void Set(Alerts alert)
        {
            for (int i = 0; i < _alerts.Length; i++)
                _alerts[i].SetActive(i == (int)alert);
        }
    }
}
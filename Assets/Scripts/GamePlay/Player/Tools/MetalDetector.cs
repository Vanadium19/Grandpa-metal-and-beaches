using UnityEngine;

internal class MetalDetector : MonoBehaviour
{
    [SerializeField] private ScrapCollector _scrapCollector;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Scrap scrap))        
            _scrapCollector.Collect(scrap);        
    }
}

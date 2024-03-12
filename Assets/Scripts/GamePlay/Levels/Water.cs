using UnityEngine;

internal class Water : MonoBehaviour
{
    [SerializeField] private WarningView _warningView;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.StartHeightTracking();
            _warningView.Set(WarningNames.Alerts.Water);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.StopHeightTracking();
            _warningView.Close(WarningNames.Alerts.Water);
        }
    }
}

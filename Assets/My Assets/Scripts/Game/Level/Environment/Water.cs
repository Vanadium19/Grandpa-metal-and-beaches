using UnityEngine;
using UnityEngine.Events;

public class Water : MonoBehaviour
{
    public event UnityAction<WarningNames.Alerts> PlayerEntered;
    public event UnityAction<WarningNames.Alerts> PlayerLeft;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.StartHeightTracking();
            PlayerEntered?.Invoke(WarningNames.Alerts.Water);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.StopHeightTracking();
            PlayerLeft?.Invoke(WarningNames.Alerts.Water);
        }
    }
}

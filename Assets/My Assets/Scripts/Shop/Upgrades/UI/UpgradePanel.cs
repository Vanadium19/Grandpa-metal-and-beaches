using UnityEngine;
using UnityEngine.Events;

public class UpgradePanel : MonoBehaviour
{
    public event UnityAction PlayerUpgraded;

    private void OnDisable()
    {
        PlayerUpgraded?.Invoke();
    }
}

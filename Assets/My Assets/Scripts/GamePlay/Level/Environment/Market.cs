using UnityEngine;

internal class Market : MonoBehaviour
{
    [SerializeField] private GameObject _pointer;
    [SerializeField] private GameObject _updateMenu;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.StopMove();
            _pointer.SetActive(false);
            _updateMenu.SetActive(true);
        }
    }
}
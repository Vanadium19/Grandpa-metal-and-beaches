using UnityEngine;

internal class Market : MonoBehaviour
{
    [SerializeField] private GameObject _pointer;
    [SerializeField] private GameObject _updateMenu;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            Time.timeScale = 0;
            _pointer.SetActive(false);
            _updateMenu.SetActive(true); 
        }
    }
}

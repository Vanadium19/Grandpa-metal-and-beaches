using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField] private GameObject _updateMenu;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            Time.timeScale = 0;
            _updateMenu.SetActive(true);        
        }
    }
}

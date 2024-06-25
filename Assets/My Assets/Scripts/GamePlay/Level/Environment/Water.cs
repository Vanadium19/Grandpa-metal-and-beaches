using GMB.GamePlay.PlayerEnvironment;
using UnityEngine;

namespace GMB.GamePlay.Level.Environment
{
    internal class Water : MonoBehaviour
    {
        [SerializeField] private GameObject _alertPanel;
        [SerializeField] private AudioSource _alertSound;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                player.StartHeightTracking();
                _alertPanel.SetActive(true);
                _alertSound.Play();
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                player.StopHeightTracking();
                _alertPanel.SetActive(false);
            }
        }
    }
}
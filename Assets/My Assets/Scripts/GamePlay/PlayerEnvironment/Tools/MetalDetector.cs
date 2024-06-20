using UnityEngine;

namespace GMB.GamePlay.PlayerEnvironment
{
    internal class MetalDetector : MonoBehaviour
    {
        [SerializeField] private ScrapCollector _scrapCollector;
        [SerializeField] private SoundPlayer _soundPlayer;
        [SerializeField] private Wallet _wallet;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Scrap scrap) && scrap.IsCollected == false)
                _scrapCollector.Collect(scrap);
            else if (collider.TryGetComponent(out Money money))
                CollectMoney(money);
        }

        private void CollectMoney(Money money)
        {
            _wallet.AddMoney(money.Value);
            _soundPlayer.Play();
            money.Collect();
        }
    }
}
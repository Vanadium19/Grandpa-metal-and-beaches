using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal class RewardButton : MonoBehaviour
{
    private readonly float _rewardMoneyCount = 25f;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private VideoAd _videoAd;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(AddReward);

    private void OnDisable() => _button.onClick.RemoveListener(AddReward);

    private void AddReward() => _videoAd.Show(_button, _wallet.AddMoney, _rewardMoneyCount);
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(VideoAd))]
public class AdvertisingButton : MonoBehaviour
{
    private readonly float _percentFactor = 100f;
    private readonly float _maxRewardPercent = 50f;

    [SerializeField] private TMP_Text _rewardView;

    private Button _button;
    private VideoAd _videoAd;
    private float _money;
    private Wallet _wallet;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _videoAd = GetComponent<VideoAd>();
    }

    private void OnEnable() => _button.onClick.AddListener(Show);

    private void OnDisable() => _button.onClick.RemoveListener(Show);

    public void Initialize(bool isRelevantProduct, Wallet wallet, float price)
    {
        _wallet = wallet;
        _money = price - wallet.Money;

        if (isRelevantProduct && _money > 0 && _money * _percentFactor / price < _maxRewardPercent)        
            TuneView();        
        else
            gameObject.SetActive(false);

    }

    private void Show() => _videoAd.Show(_wallet, _money);

    private void TuneView()
    {
        gameObject.SetActive(true);
        _rewardView.text = $"+{_money}";
    }
}

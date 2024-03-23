using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GoodRenderer))]
internal class Good : MonoBehaviour
{
    [SerializeField] private GoodInfo _goodInfo;
    [SerializeField] private Button _sellButton;
    [SerializeField] private AdvertisingButton _advertisingButton;

    private GoodRenderer _goodRenderer;
    private Transform _goodPicture;
    private Wallet _wallet;

    public string Name => _goodInfo.Name;
    public bool IsSold => Convert.ToBoolean(PlayerPrefs.GetInt(_goodInfo.Name, 0));

    private void Awake() => _goodRenderer = GetComponent<GoodRenderer>();

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClicked);
        _advertisingButton.Initialize(!IsSold, _wallet, _goodInfo.Price);
    }

    private void Start()
    {
        _goodRenderer.Render(_goodInfo);

        if (IsSold)
            _sellButton.interactable = false;
    }

    private void OnDisable() => _sellButton.onClick.RemoveListener(OnSellButtonClicked);

    public void Initialize(Wallet wallet, Transform goodPicture)
    {
        _wallet = wallet;
        _goodPicture = goodPicture;
    }

    public void Install() => _goodPicture.gameObject.SetActive(true);

    private void OnSellButtonClicked()
    {
        if (_wallet.TryBuy(_goodInfo.Price))
            Buy();
    }

    private void Buy()
    {
        Install();
        _sellButton.interactable = false;
        PlayerPrefs.SetInt(_goodInfo.Name, Convert.ToInt16(true));
        PlayerPrefs.Save();
    }
}

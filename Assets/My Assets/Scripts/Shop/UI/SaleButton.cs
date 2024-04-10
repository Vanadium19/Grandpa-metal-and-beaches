using UnityEngine;

internal class SaleButton : UpgradePlayerButton
{
    [SerializeField] private Menu _menu;

    private readonly float _saleFactor = 0.75f;

    protected override float GetPrice() => Mathf.Round(_saleFactor * base.GetPrice());

    protected override void OffButton() => gameObject.SetActive(false);

    protected override void Buy(float price)
    {
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, () => base.Buy(price), OnCloseCallback);
    }

    private void OnOpenCallback()
    {
        _menu.StopTime();
        _menu.StopMusic();
    }

    private void OnCloseCallback()
    {
        _menu.ContinueTime();
        _menu.ContinueMusic();
    }
}

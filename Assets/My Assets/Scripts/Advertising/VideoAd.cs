using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VideoAd : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    private Button _button;

    public void Show(Button lockableButton, UnityAction<float> moneyAction, float money)
    {
        _button = lockableButton;
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, () => moneyAction?.Invoke(money), OnCloseCallback);
    }

    private void OnOpenCallback()
    {
        _menu.StopTime();
        _menu.StopMusic();
        _button.interactable = false;
    }

    private void OnCloseCallback()
    {
        _menu.ContinueTime();
        _menu.ContinueMusic();
        _button.interactable = true;
    }
}

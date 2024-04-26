using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal class LeaderboardOpener : MonoBehaviour
{
    [SerializeField] private YandexLeaderboardFiller _leaderboardFiller;
    [SerializeField] private GameObject _leaderboardPanel;
    [SerializeField] private GameObject _authorizePanel;

    private Button _leaderboardButton;

    private void Awake() => _leaderboardButton = GetComponent<Button>();

    private void OnEnable() => _leaderboardButton.onClick.AddListener(OnLeaderboardButtonClick);

    private void OnDisable() => _leaderboardButton.onClick.RemoveListener(OnLeaderboardButtonClick);

    private void OnLeaderboardButtonClick() => OpenLeaderboard();

    private void OpenLeaderboard()
    {
        if (PlayerAccount.IsAuthorized == false)
            _authorizePanel.SetActive(true);

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
            return;

        _leaderboardFiller.Fill();
        _leaderboardPanel.SetActive(true);
    }
}
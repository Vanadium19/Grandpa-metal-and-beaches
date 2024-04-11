using Agava.YandexGames;
using UnityEngine;

public class YandexLeaderboardScoreSetter : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";

    public void UpdatePlayerScore(float weight) => SetPlayerScore((int)Mathf.Round(weight));

    public void SetPlayerScore(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result.score < score || result == null)
                Leaderboard.SetScore(LeaderboardName, score);
        });
    }
}

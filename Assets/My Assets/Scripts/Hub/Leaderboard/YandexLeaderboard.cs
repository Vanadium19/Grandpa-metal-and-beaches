using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

internal class YandexLeaderboard : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";
    private const string AnonymousName = "Anonymous";

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new List<LeaderboardPlayer>();

    [SerializeField] private LeaderboardView _leaderboardView;

    public void UpdatePlayerScore() => SetPlayerScore((int)Mathf.Round(PlayerPrefs.GetFloat(GameSaver.Weight)));

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

    public void Fill()
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        _leaderboardPlayers.Clear();

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            foreach (var entry in result.entries)
            {
                int rank = entry.rank;
                int score = entry.score;
                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderboardPlayers.Add(new LeaderboardPlayer(name, rank, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }
}

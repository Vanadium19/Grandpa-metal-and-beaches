using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

internal class YandexLeaderboardFiller : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";
    private const string EnglishAnonymousName = "Anonymous";
    private const string RussianAnonymousName = "Аноним";
    private const string TurkishAnonymousName = "Isimsiz";

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new List<LeaderboardPlayer>();

    [SerializeField] private LeaderboardView _leaderboardView;

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
                    name = GetAnonymousName();

                _leaderboardPlayers.Add(new LeaderboardPlayer(name, rank, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }

    private string GetAnonymousName() => YandexGamesSdk.Environment.i18n.lang switch
    {
        Localizer.Russian => RussianAnonymousName,
        Localizer.English => EnglishAnonymousName,
        Localizer.Turkish => TurkishAnonymousName,
        _ => EnglishAnonymousName,
    };
}

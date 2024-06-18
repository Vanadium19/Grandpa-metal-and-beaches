using System.Collections.Generic;
using UnityEngine;

internal class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private LeaderboardElement _leaderboardPrefab;

    private List<LeaderboardElement> _spawnElements = new List<LeaderboardElement>();

    public void ConstructLeaderboard(List<LeaderboardPlayer> leaderboardPlayers)
    {
        ClearLeaderboard();

        foreach (var player in leaderboardPlayers)
        {
            LeaderboardElement leaderboardElement = Instantiate(_leaderboardPrefab, _container);
            leaderboardElement.Initialize(player.Name, player.Rank, player.Score);
            _spawnElements.Add(leaderboardElement);
        }
    }

    private void ClearLeaderboard()
    {
        foreach (var spawnElement in _spawnElements)
            Destroy(spawnElement.gameObject);

        _spawnElements = new List<LeaderboardElement>();
    }
}
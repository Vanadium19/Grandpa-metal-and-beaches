using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(YandexLeaderboardScoreSetter))]
internal class LeaderboardUpdater : MonoBehaviour
{
    private readonly float _leaderboardDelay = 2f;

    private YandexLeaderboardScoreSetter _leaderboardScoreSetter;
    private Coroutine _scoreUpdating;

    private void Awake() => _leaderboardScoreSetter = GetComponent<YandexLeaderboardScoreSetter>();

    public void Execute(float weight)
    {
        if (_scoreUpdating != null)
            StopCoroutine(_scoreUpdating);

        _scoreUpdating = StartCoroutine(UpdateLeaderboardScore(weight));
    }

    private IEnumerator UpdateLeaderboardScore(float weight)
    {
        yield return new WaitForSeconds(_leaderboardDelay);
        _leaderboardScoreSetter.UpdatePlayerScore(weight);
    }
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(YandexLeaderboardScoreSetter))]
internal class LeaderboardUpdater : MonoBehaviour
{
    private readonly float _delayTime = 2f;

    private YandexLeaderboardScoreSetter _leaderboardScoreSetter;
    private Coroutine _scoreUpdating;
    private WaitForSeconds _delay;

    private void Awake()
    {
        _leaderboardScoreSetter = GetComponent<YandexLeaderboardScoreSetter>();
        _delay = new WaitForSeconds(_delayTime);
    }

    public void Execute(float weight)
    {
        if (_scoreUpdating != null)
            StopCoroutine(_scoreUpdating);

        _scoreUpdating = StartCoroutine(UpdateLeaderboardScore(weight));
    }

    private IEnumerator UpdateLeaderboardScore(float weight)
    {
        yield return _delay;
        _leaderboardScoreSetter.UpdatePlayerScore(weight);
    }
}
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(YandexLeaderboardScoreSetter))]
internal class LevelEnder : MonoBehaviour
{
    [SerializeField] private GameObject _endLevelButton;
    [SerializeField] private Dumpster _dumpster;
    [SerializeField] private CongratulationsPanel _congratulationsPanel;
    
    private float _targetWeight;
    private float _currentWeight;
    private YandexLeaderboardScoreSetter _leaderboardScoreSetter;

    private void Awake() => _leaderboardScoreSetter = GetComponent<YandexLeaderboardScoreSetter>();

    private void OnEnable() => _dumpster.ScrapCollected += UpdateProgress;

    private void OnDisable() => _dumpster.ScrapCollected -= UpdateProgress;

    public void Initialize(float targetWeight) => _targetWeight = targetWeight;

    private void UpdateProgress(Scrap scrap)
    {
        AddWeight(scrap.Info.Weight);

        if (_currentWeight >= _targetWeight)
            StartCoroutine(FinishLevel());
    }

    private void AddWeight(float weight)
    {
        _currentWeight += weight;
        PlayerPrefs.SetFloat(GameSaver.Weight, PlayerPrefs.GetFloat(GameSaver.Weight) + weight);
        PlayerPrefs.Save();
    }

    private IEnumerator FinishLevel()
    {
        _dumpster.ScrapCollected -= UpdateProgress;
        _congratulationsPanel.Activate(_targetWeight);
        yield return new WaitUntil(() => _congratulationsPanel.IsFinished);
        _congratulationsPanel.gameObject.SetActive(false);
        _leaderboardScoreSetter.UpdatePlayerScore();
        _endLevelButton.SetActive(true);
    }
}

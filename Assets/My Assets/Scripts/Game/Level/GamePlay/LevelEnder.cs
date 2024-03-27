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
    private Coroutine _levelFinishing;

    private void Awake()
    {
        _leaderboardScoreSetter = GetComponent<YandexLeaderboardScoreSetter>();
        _currentWeight = PlayerPrefs.GetFloat(GameSaver.CurrentWeight);
    }

    private void OnEnable() => _dumpster.ScrapCollected += UpdateProgress;

    private void OnDisable() => _dumpster.ScrapCollected -= UpdateProgress;

    public void Initialize(float targetWeight) => _targetWeight = targetWeight;

    private void UpdateProgress(Scrap scrap)
    {
        AddWeight(scrap.Info.Weight);

        if (_levelFinishing == null && _currentWeight >= _targetWeight)
            _levelFinishing = StartCoroutine(FinishLevel());
    }

    private void AddWeight(float weight)
    {
        var allWeight = PlayerPrefs.GetFloat(GameSaver.Weight) + weight;

        _currentWeight += weight;
        SaveProgress(allWeight);

#if UNITY_WEBGL && !UNITY_EDITOR
 _leaderboardScoreSetter.UpdatePlayerScore(allWeight);
#endif
    }

    private void SaveProgress(float allWeight)
    {
        PlayerPrefs.SetFloat(GameSaver.Weight, allWeight);

        if (_levelFinishing == null)
            PlayerPrefs.SetFloat(GameSaver.CurrentWeight, _currentWeight);

        PlayerPrefs.Save();
    }

    private void ResetProgress()
    {
        PlayerPrefs.SetFloat(GameSaver.CurrentWeight, 0);
        PlayerPrefs.Save();
    }

    private IEnumerator FinishLevel()
    {
        _congratulationsPanel.Activate(_targetWeight);
        yield return new WaitUntil(() => _congratulationsPanel.IsFinished);
        _congratulationsPanel.gameObject.SetActive(false);
        _endLevelButton.SetActive(true);      
        ResetProgress();
    }
}

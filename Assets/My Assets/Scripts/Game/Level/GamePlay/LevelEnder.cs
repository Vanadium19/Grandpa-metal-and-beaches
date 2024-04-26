using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LeaderboardUpdater))]
internal class LevelEnder : MonoBehaviour
{
    [SerializeField] private GameObject _endLevelButton;
    [SerializeField] private Dumpster _dumpster;
    [SerializeField] private CongratulationsPanel _congratulationsPanel;

    private float _targetWeight;
    private float _currentWeight;
    private LeaderboardUpdater _leaderboardUpdater;
    private bool _isLevelEnded;

    private void Awake() => _leaderboardUpdater = GetComponent<LeaderboardUpdater>();

    private void OnEnable() => _dumpster.ScrapCollected += UpdateProgress;

    private void OnDisable() => _dumpster.ScrapCollected -= UpdateProgress;

    public void Initialize(float targetWeight, float currentWeight)
    {
        _targetWeight = targetWeight;
        _currentWeight = currentWeight;
        _isLevelEnded = _currentWeight >= _targetWeight;
        _endLevelButton.SetActive(_isLevelEnded);
    }

    private void AddWeight(float weight)
    {
        var allWeight = PlayerPrefs.GetFloat(GameSaverData.Weight) + weight;

        _currentWeight += weight;
        SaveProgress(allWeight);

#if UNITY_WEBGL && !UNITY_EDITOR
_leaderboardUpdater.Execute(allWeight);
#endif
    }

    private void SaveProgress(float allWeight)
    {
        PlayerPrefs.SetFloat(GameSaverData.Weight, allWeight);
        PlayerPrefs.SetFloat(GameSaverData.CurrentWeight, _currentWeight);
        PlayerPrefs.Save();
    }

    private IEnumerator FinishLevel()
    {
        _isLevelEnded = true;
        _congratulationsPanel.Activate(_targetWeight);
        yield return new WaitUntil(() => _congratulationsPanel.IsFinished);
        _congratulationsPanel.gameObject.SetActive(false);
        _endLevelButton.SetActive(true);
    }

    private void UpdateProgress(Scrap scrap)
    {
        AddWeight(scrap.Info.Weight);

        if (!_isLevelEnded && _currentWeight >= _targetWeight)
            StartCoroutine(FinishLevel());
    }
}

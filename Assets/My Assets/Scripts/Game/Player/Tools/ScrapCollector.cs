using UnityEngine;
using UnityEngine.Events;

public enum Alerts
{
    BagCrowded = 0,
    OutOfLevel
};

public class ScrapCollector : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private ScrapMagnet _scrapMagnet;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private ScrapSounds _scrapSounds;

    private float _level;

    public event UnityAction<Alerts> Alarmed;

    private void Awake() => _level = PlayerPrefs.GetFloat(GameSaverData.ScrapCollector);

    private void OnEnable() => _playerStats.PlayerUpgraded += SetLevel;

    private void OnDisable() => _playerStats.PlayerUpgraded -= SetLevel;

    public void Collect(Scrap scrap)
    {
        if (scrap.Info.Rank > _level)
            Alarmed?.Invoke(Alerts.OutOfLevel);
        else if (_bag.CanAdd(scrap) == false)
            Alarmed?.Invoke(Alerts.BagCrowded);
        else
            Put(scrap);
    }

    private void Put(Scrap scrap)
    {
        scrap.Collect();
        _bag.Add(scrap);
        _scrapMagnet.StartAttract(scrap.transform);
        _scrapSounds.Play();
    }

    private void SetLevel(float level) => _level = level;
}

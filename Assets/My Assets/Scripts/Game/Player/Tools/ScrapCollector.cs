using UnityEngine;
using UnityEngine.Events;

public class ScrapCollector : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private ScrapMagnet _scrapMagnet;
    [SerializeField] private UpgradePanel _upgradePanel;
    [SerializeField] private ScrapSounds _scrapSounds;

    private float _level;

    public event UnityAction<Alerts> Alarmed;

    private void Awake() => SetLevel();

    private void OnEnable() => _upgradePanel.PlayerUpgraded += SetLevel;

    private void OnDisable() => _upgradePanel.PlayerUpgraded -= SetLevel;

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

    private void SetLevel() => _level = PlayerPrefs.GetFloat(GameSaver.ScrapCollector);

    public enum Alerts
    {
        BagCrowded = 0,
        OutOfLevel
    }
}

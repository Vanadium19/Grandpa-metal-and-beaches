using UnityEngine;
using UnityEngine.Events;

public class ScrapCollector : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private ScrapMagnet _scrapMagnet;
    [SerializeField] private UpgradePanel _upgradePanel;    

    private float _level;

    public event UnityAction ScrapCollected;
    public event UnityAction<WarningNames.Alerts> Alarmed;

    private void Awake() => SetLevel();

    private void OnEnable() => _upgradePanel.PlayerUpgraded += SetLevel;

    private void OnDisable() => _upgradePanel.PlayerUpgraded -= SetLevel;

    public void Collect(Scrap scrap)
    {
        if (scrap.Info.Rank > _level)
            Alarmed?.Invoke(WarningNames.Alerts.OutOfLevel);
        else if (_bag.CanAdd(scrap) == false)
            Alarmed?.Invoke(WarningNames.Alerts.BagCrowded);
        else
            Put(scrap);        
    }

    private void Put(Scrap scrap)
    {
        scrap.Collect();
        _bag.Add(scrap);
        _scrapMagnet.StartAttract(scrap.transform);
        ScrapCollected?.Invoke();
    }

    private void SetLevel() => _level = PlayerPrefs.GetFloat(GameSaver.ScrapCollector);
}

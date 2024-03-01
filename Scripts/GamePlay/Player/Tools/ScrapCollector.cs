using UnityEngine;
using UnityEngine.Events;

public class ScrapCollector : MonoBehaviour
{
    [SerializeField] private Bag _bag;

    private float _level;

    public event UnityAction ScrapCollected;
    public event UnityAction<WarningNames.Alerts> Alarmed;

    private void Awake() => _level = PlayerPrefs.GetFloat(GameSaver.ScrapCollector);

    public void Collect(Scrap scrapMetal)
    {
        if (scrapMetal.Info.Rank > _level)        
            Alarmed?.Invoke(WarningNames.Alerts.OutOfLevel);        
        else if (_bag.CanAdd(scrapMetal) == false)
            Alarmed?.Invoke(WarningNames.Alerts.BagCrowded);
        else        
            Put(scrapMetal);        
    }

    private void Put(Scrap scrapMetal)
    {
        _bag.Add(scrapMetal);
        scrapMetal.Collect();
        ScrapCollected?.Invoke();
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "New Scrap", menuName = "Scrap/Create new Scrap", order =51)]
public class ScrapInfo : ScriptableObject
{
    [SerializeField] private float _weight;
    [SerializeField] private float _price;
    [SerializeField] private int _rank;
    [SerializeField] private string _name;

    public float Weight => _weight;
    public float Price => _price;
    public int Rank => _rank;
    public string Name => _name;
}

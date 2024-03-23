using UnityEngine;

[CreateAssetMenu(fileName = "New Good", menuName = "Goods/Create new Good", order = 53)]
internal class GoodInfo : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _price;
    [SerializeField] private Sprite _icon;

    public string Name => _name;
    public float Price => _price;
    public Sprite Icon => _icon;
}

using UnityEngine;

[CreateAssetMenu(fileName = "New Good", menuName = "Goods/Create new Good", order = 53)]
internal class GoodInfo : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Vector2 _position;
    [SerializeField] private Vector2 _size;
    [SerializeField] private Vector2 _minAnchors;
    [SerializeField] private Vector2 _maxAnchors;

    public string Name => _name;
    public float Price => _price;
    public Sprite Icon => _icon;
    public Vector2 Position => _position;
    public Vector2 Size => _size;
    public Vector2 MinAnchors => _minAnchors;
    public Vector2 MaxAnchors => _maxAnchors;
}

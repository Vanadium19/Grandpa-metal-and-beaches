using UnityEngine;

public class Stat : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private float _value;
    [SerializeField] private float _price;

    private string _name;

    public int Level => _level;
    public float Value => _value;
    public float Price => _price;
    public string Name => _name;

    protected void SetName(string value)
    {
        _name = name;
    }
}
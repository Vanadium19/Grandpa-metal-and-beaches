using UnityEngine;

public class Stat : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private float _value;
    [SerializeField] private float _price;

    public string Name { get; protected set; }
    public int Level => _level;
    public float Value => _value;
    public float Price => _price;
}

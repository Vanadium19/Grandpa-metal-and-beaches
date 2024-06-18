using UnityEngine;

public class Scrap : MonoBehaviour
{
    [SerializeField] private float _rotationAngleX;
    [SerializeField] private ScrapInfo _info;

    public bool IsCollected { get; private set; }

    public ScrapInfo Info => _info;
    public float RotationAngleX => _rotationAngleX;

    public void Collect() => IsCollected = true;
}

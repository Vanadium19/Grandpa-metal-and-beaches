using UnityEngine;

internal class Scrap : MonoBehaviour
{
    [SerializeField] private float _rotationAngleX;
    [SerializeField] private ScrapInfo _info;

    private bool _isCollected;

    public ScrapInfo Info => _info;
    public bool IsCollected => _isCollected;
    public float RotationAngleX => _rotationAngleX;

    public void Collect()
    {
        _isCollected = true;
    }
}
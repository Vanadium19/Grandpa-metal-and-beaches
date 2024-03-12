using UnityEngine;

public class Scrap : MonoBehaviour
{
    [SerializeField] private ScrapInfo _info;

    public bool IsCollected { get; private set; }

    public ScrapInfo Info => _info;

    public void Collect() => IsCollected = true;
}

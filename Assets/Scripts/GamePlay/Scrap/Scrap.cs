using UnityEngine;

public class Scrap : MonoBehaviour
{
    [SerializeField] private ScrapInfo _info;

    public ScrapInfo Info => _info;

    public void Collect() => Destroy(gameObject);
}

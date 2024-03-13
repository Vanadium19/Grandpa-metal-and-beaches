using UnityEngine;

public class DumpsterPointerSwitch : MonoBehaviour
{
    private readonly float _showPercent = 80f;
    private readonly float _percentFactor = 100f;

    [SerializeField] private Bag _bag;
    [SerializeField] private Pointer _pointer;

    private void OnEnable() => _bag.ContentChanged += TurnOnPointer;

    private void OnDisable() => _bag.ContentChanged -= TurnOnPointer;

    private void TurnOnPointer(float weight) => _pointer.gameObject.SetActive(weight / _bag.Capacity * _percentFactor > _showPercent);
}

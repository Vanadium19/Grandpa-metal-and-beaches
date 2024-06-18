using UnityEngine;

internal class DumpsterPointerSwitch : MonoBehaviour
{
    private readonly float _percentFactor = 0.8f;

    [SerializeField] private Bag _bag;
    [SerializeField] private Pointer _pointer;

    private void OnEnable()
    {
        _bag.ContentChanged += TurnOnPointer;
    }

    private void OnDisable()
    {
        _bag.ContentChanged -= TurnOnPointer;
    }

    private void TurnOnPointer(float weight)
    {
        _pointer.gameObject.SetActive(weight >= _percentFactor * _bag.Capacity);
    }
}
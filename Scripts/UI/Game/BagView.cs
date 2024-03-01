using TMPro;
using UnityEngine;

internal class BagView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Bag _bag;

    private void OnEnable() => _bag.ContentChanged += OnContentChanged;

    private void OnDisable() => _bag.ContentChanged -= OnContentChanged;

    private void OnContentChanged(float weight) => _text.text = $"{weight}/{_bag.Capacity}";
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class BagView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private Bag _bag;

    private void OnEnable()
    {
        _bag.ContentChanged += OnContentChanged;
    }

    private void OnDisable()
    {
        _bag.ContentChanged -= OnContentChanged;
    }

    private void OnContentChanged(float weight)
    {
        _text.text = $"{_bag.Capacity}\n{weight}";
        _image.fillAmount = weight / _bag.Capacity;
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class GoodRenderer : MonoBehaviour
{
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;

    public void Render(GoodInfo _goodInfo)
    {
        _price.text = _goodInfo.Price.ToString();
        _icon.sprite = _goodInfo.Icon;
    }
}

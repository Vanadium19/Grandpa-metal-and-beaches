using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
internal class ButtonDisplay : MonoBehaviour
{
    private readonly string _maxText = "max";

    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private GameObject _videoAdIcon;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimationTrigger(int triggerName)
    {
        _animator.SetTrigger(triggerName);
    }

    public void SetSlider(float value)
    {
        _slider.value = value;
    }

    public void Off()
    {
        _videoAdIcon.SetActive(false);
        _price.text = _maxText;
    }

    public void UpdatePrice(bool isSalePrice, float price)
    {
        _videoAdIcon.SetActive(isSalePrice);
        _price.text = price.ToString();
    }
}
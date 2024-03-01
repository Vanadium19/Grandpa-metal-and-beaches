using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CongratulationsView : MonoBehaviour
{
    private readonly float _delay = 0.01f;

    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    public bool IsFinished { get; private set; }
    
    public void StartCongratulate(float currentValue, float targetValue)
    {
        StartCoroutine(Congratulate(currentValue, targetValue));
    }

    private IEnumerator Congratulate(float currentValue, float targetValue)
    {
        var delay = new WaitForSeconds(_delay);
        float value = 0;

        while (value <= currentValue)
        {
            if (value > targetValue)
                _image.fillAmount = (value - targetValue) / targetValue;
            else
                _image.fillAmount = value / targetValue;

            _text.text = $"{value}/{targetValue}";

            value++;
            yield return delay;
        }

        IsFinished = true;
    }
}

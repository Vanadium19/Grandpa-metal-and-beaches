using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CongratulationsPanel : MonoBehaviour
{
    private readonly WaitForSeconds _additionDelay = new WaitForSeconds(0.01f);
    private readonly WaitForSeconds _closePanelDelay = new WaitForSeconds(2f);

    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    public bool IsFinished { get; private set; }

    public void Activate(float targetValue)
    {
        gameObject.SetActive(true);
        _player.StopMove();
        StartCoroutine(Congratulate(targetValue));
    }

    private IEnumerator Congratulate(float targetValue)
    {
        float value = 0;

        while (value <= targetValue)
        {
            _slider.value = value / targetValue;
            _text.text = $"{value}/{targetValue}";
            value++;

            yield return _additionDelay;
        }

        yield return _closePanelDelay;

        _player.ContinueMove();
        IsFinished = true;
    }
}

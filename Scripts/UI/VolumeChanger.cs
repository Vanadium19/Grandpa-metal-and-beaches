using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
internal class VolumeChanger : MonoBehaviour
{
    private Slider _slider;

    private void Awake() => _slider = GetComponent<Slider>();

    private void Start() => _slider.value = AudioListener.volume;

    public void Change(float value)
    {
        AudioListener.volume = Mathf.Clamp01(value);
        PlayerPrefs.SetFloat(GameSaver.Audio, AudioListener.volume);
    }
}

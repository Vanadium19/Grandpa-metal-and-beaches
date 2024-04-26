using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal class VolumeButton : MonoBehaviour
{
    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1f;

    [SerializeField] private FocusTracker _focusTracker;
    [SerializeField] private Sprite _volumeOffImage;
    [SerializeField] private Image _icon;

    private Sprite _volumeOnImage;
    private Button _volumeButton;

    private void Awake()
    {
        _volumeButton = GetComponent<Button>();
        _volumeOnImage = _icon.sprite;
    }

    private void OnEnable()
    {
        _volumeButton.onClick.AddListener(Change);
    }

    private void Start()
    {
        _icon.sprite = AudioListener.volume == _maxVolume ? _volumeOnImage : _volumeOffImage;
    }

    private void OnDisable()
    {
        _volumeButton.onClick.RemoveListener(Change);
    }

    public void Change()
    {
        var volume = Mathf.Approximately(AudioListener.volume, _maxVolume) ? _minVolume : _maxVolume;

        AudioListener.volume = volume;
        _focusTracker.SetCurrentVolume(volume);
        _icon.sprite = Mathf.Approximately(volume, _minVolume) ? _volumeOffImage : _volumeOnImage;

        PlayerPrefs.SetFloat(GameSaverData.Audio, volume);
        PlayerPrefs.Save();
    }
}

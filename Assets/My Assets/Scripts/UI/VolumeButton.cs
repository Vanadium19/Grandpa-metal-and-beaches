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

        _icon.sprite = Mathf.Approximately(AudioListener.volume, _maxVolume) ? _volumeOnImage : _volumeOffImage;
    }

    private void OnDisable()
    {
        _volumeButton.onClick.RemoveListener(Change);
    }

    public void Change()
    {
        float volume = AudioListener.volume;

        if (Mathf.Approximately(volume, _maxVolume))
        {
            volume = _minVolume;
            _icon.sprite = _volumeOffImage;
        }
        else
        {
            volume = _maxVolume;
            _icon.sprite = _volumeOnImage;
        }

        _focusTracker.SetCurrentVolume(volume);
        AudioListener.volume = volume;
        GameSaver.SetVolume(volume);
    }
}
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
internal class VolumeButton : MonoBehaviour
{
    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1f;

    [SerializeField] private Sprite _volumeOffImage;    

    private Sprite _volumeOnImage;
    private Button _volumeButton;
    private Image _icon;

    private void Awake()
    {
        _volumeButton = GetComponent<Button>();
        _icon = GetComponent<Image>();
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
        AudioListener.volume = AudioListener.volume == _maxVolume ? _minVolume : _maxVolume;
        _icon.sprite = _icon.sprite == _volumeOnImage ? _volumeOffImage : _volumeOnImage;
        GameSaver.SaveVolume();
    }
}

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
internal class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _background;
    private float _imagePositionX;

    private void Awake()
    {
        _background = GetComponent<RawImage>();
        _imagePositionX = _background.uvRect.x;
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;

        _background.uvRect = new Rect(_imagePositionX, 0, _background.uvRect.width, _background.uvRect.height);
    }
}
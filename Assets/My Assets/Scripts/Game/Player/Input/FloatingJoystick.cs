using UnityEngine;
using UnityEngine.EventSystems;

public enum AxisOptions
{
    Both,
    Horizontal,
    Vertical
};

internal class FloatingJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private readonly float _snappingValue = 1f;
    private readonly float _snappingZeroValue = 0f;
    private readonly float _horizontalMinAngle = 22.5f;
    private readonly float _horizontalMaxAngle = 157.5f;
    private readonly float _verticalMinAngle = 67.5f;
    private readonly float _verticalMaxAngle = 112.5f;
    private readonly float _radiusFactor = 2f;
    private readonly float _maxMagnitude = 1f;
    private readonly Vector2 _imageCenter = new Vector2(0.5f, 0.5f);

    [SerializeField] private AxisOptions _axisOptions = AxisOptions.Both;
    [SerializeField] private RectTransform _background = null;
    [SerializeField] private RectTransform _handle = null;
    [SerializeField] private float _handleRange = 1;
    [SerializeField] private float _deadZone = 0;
    [SerializeField] private bool _snapX = false;
    [SerializeField] private bool _snapY = false;

    private Vector2 _input = Vector2.zero;
    private RectTransform _baseRect = null;
    private Canvas _canvas;
    private Camera _cam;

    public float Horizontal => _snapX ? SnapFloat(_input.x, AxisOptions.Horizontal) : _input.x;
    public float Vertical => _snapY ? SnapFloat(_input.y, AxisOptions.Vertical) : _input.y;
    public Vector2 Direction => new Vector2(Horizontal, Vertical);

    public float HandleRange
    {
        get => _handleRange;
        set => _handleRange = Mathf.Abs(value);
    }

    public float DeadZone
    {
        get => _deadZone;
        set => _deadZone = Mathf.Abs(value);
    }

    public AxisOptions AxisOptions
    {
        get => AxisOptions;
        set => _axisOptions = value;
    }
    public bool SnapX
    {
        get => _snapX;
        set => _snapX = value;
    }
    public bool SnapY
    {
        get => _snapY;
        set => _snapY = value;
    }

    private void Start()
    {
        HandleRange = _handleRange;
        DeadZone = _deadZone;
        _baseRect = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();

        if (_canvas == null)
            Debug.LogError("The Joystick is not placed inside a canvas");

        _background.pivot = _imageCenter;
        _handle.anchorMin = _imageCenter;
        _handle.anchorMax = _imageCenter;
        _handle.pivot = _imageCenter;
        _handle.anchoredPosition = Vector2.zero;

        _background.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        _background.gameObject.SetActive(true);

        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _cam = null;

        if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
            _cam = _canvas.worldCamera;

        Vector2 position = RectTransformUtility.WorldToScreenPoint(_cam, _background.position);
        Vector2 radius = _background.sizeDelta / _radiusFactor;
        _input = (eventData.position - position) / (radius * _canvas.scaleFactor);
        FormatInput();
        HandleInput(_input.magnitude, _input.normalized, radius, _cam);
        _handle.anchoredPosition = _input * radius * _handleRange;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _background.gameObject.SetActive(false);

        _input = Vector2.zero;
        _handle.anchoredPosition = Vector2.zero;
    }

    private void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > _deadZone)
        {
            if (magnitude > _maxMagnitude)
            {
                _input = normalised;
            }
        }
        else
        {
            _input = Vector2.zero;
        }
    }

    private void FormatInput()
    {
        if (_axisOptions == AxisOptions.Horizontal)
            _input = Vector2.right * _input.x;
        else if (_axisOptions == AxisOptions.Vertical)
            _input = Vector2.up * _input.y;
    }

    private float SnapFloat(float value, AxisOptions snapAxis)
    {
        if (value == _snappingZeroValue)
            return value;

        if (_axisOptions == AxisOptions.Both)
        {
            float angle = Vector2.Angle(_input, Vector2.up);

            if (snapAxis == AxisOptions.Horizontal)
            {
                if (angle < _horizontalMinAngle || angle > _horizontalMaxAngle)
                    return _snappingZeroValue;
                else
                    return (value > _snappingZeroValue) ? _snappingValue : -_snappingValue;
            }
            else if (snapAxis == AxisOptions.Vertical)
            {
                if (angle > _verticalMinAngle && angle < _verticalMaxAngle)
                    return _snappingZeroValue;
                else
                    return (value > _snappingZeroValue) ? _snappingValue : -_snappingValue;
            }

            return value;
        }
        else
        {
            if (value > _snappingZeroValue)
                return _snappingValue;

            if (value < _snappingZeroValue)
                return -_snappingValue;
        }

        return _snappingZeroValue;
    }

    private Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
    {
        Vector2 localPoint = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_baseRect, screenPosition, _cam, out localPoint))
        {
            Vector2 pivotOffset = _baseRect.pivot * _baseRect.sizeDelta;
            return localPoint - (_background.anchorMax * _baseRect.sizeDelta) + pivotOffset;
        }

        return Vector2.zero;
    }
}
using UnityEngine;

internal class PlayerInput : MonoBehaviour
{
    [SerializeField] private FixedJoystick _fixedJoystick;

    public Vector3 MoveInput { get; private set; }    

    private void Update() => MoveInput = _fixedJoystick.Horizontal * Vector3.right + _fixedJoystick.Vertical * Vector3.forward;
}

using UnityEngine;

internal class PlayerInput : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    public Vector3 MoveInput { get; private set; }

    private void Update() => Input();

    private void Input()
    {
        MoveInput = _joystick.Horizontal * Vector3.right + _joystick.Vertical * Vector3.forward;

        if (MoveInput != Vector3.zero)
            return;

        MoveInput = UnityEngine.Input.GetAxis("Horizontal") * Vector3.right + UnityEngine.Input.GetAxis("Vertical") * Vector3.forward;
    }
}

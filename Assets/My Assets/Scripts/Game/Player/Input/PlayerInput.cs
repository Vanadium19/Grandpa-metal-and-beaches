using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    public Vector3 MoveInput { get; private set; }

    private void Update()
    {
        InputMove();
    }

    private void InputMove()
    {
        MoveInput = _joystick.Horizontal * Vector3.right + _joystick.Vertical * Vector3.forward;

        if (MoveInput != Vector3.zero)
            return;

        MoveInput = Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.forward;
    }
}

using UnityEngine;

namespace GMB.GamePlay.PlayerEnvironment
{
    public class PlayerInput : MonoBehaviour
    {
        private readonly string HorizontalAxis = "Horizontal";
        private readonly string VerticalAxis = "Vertical";

        [SerializeField] private FloatingJoystick _joystick;

        private Vector3 _moveInput;

        public Vector3 MoveInput => _moveInput;

        private void Update()
        {
            InputMove();
        }

        private void InputMove()
        {
            _moveInput = _joystick.Horizontal * Vector3.right + _joystick.Vertical * Vector3.forward;

            if (_moveInput != Vector3.zero)
                return;

            _moveInput = Input.GetAxis(HorizontalAxis) * Vector3.right + Input.GetAxis(VerticalAxis) * Vector3.forward;
        }
    }
}
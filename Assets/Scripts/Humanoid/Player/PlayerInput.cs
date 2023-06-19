using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _movingJoystick;
    [SerializeField] private FloatingJoystick _shootingJoystick;

    private ShootingJoystick _handleShootingJoystick;

    public Vector2 MovementDirection { get; private set; }
    public Vector2 LookDirection { get; private set; }

    public bool ShootingJoystickActive => _handleShootingJoystick.gameObject.activeInHierarchy;

    private void Awake()
    {
        _handleShootingJoystick = _shootingJoystick.GetComponentInChildren<ShootingJoystick>();
    }

    private void Update()
    {
        MovementDirection = GetMovementInputAxis();
        LookDirection = GetLookInputAxis();
    }

    private Vector2 GetMovementInputAxis() => GetJoystickInputAxis(_movingJoystick);
    private Vector2 GetLookInputAxis() => GetJoystickInputAxis(_shootingJoystick);

    private Vector2 GetJoystickInputAxis(Joystick joystick)
    {
        return joystick.Direction.magnitude > 0 ?
            new Vector2(joystick.Horizontal, joystick.Vertical) :
            Vector2.zero;
    }
}

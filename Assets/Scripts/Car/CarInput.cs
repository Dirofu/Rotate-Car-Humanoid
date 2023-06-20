using UnityEngine;

public class CarInput : MonoBehaviour
{
    [Header("Joystick Controller Settings")]
    [SerializeField] private GameObject _joystickController;
    [SerializeField] private FixedJoystick _verticalJoystick;
    [SerializeField] private FixedJoystick _horizontalJoystick;

    public float VerticalValue { get; private set; }
    public float HorizontalValue { get; private set; }


    private void Update()
    {
        if (_joystickController.activeInHierarchy == true)
        {
            VerticalValue = _verticalJoystick.Vertical;
            HorizontalValue = _horizontalJoystick.Horizontal;
        }
    }

    public void SetAccel(int value) => VerticalValue = value;
    public void SetSteer(int value) => HorizontalValue = value;
}

using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private PlayerAnimation _animation;
    private PlayerInput _input;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
        _animation = GetComponent<PlayerAnimation>();
    }

    private void FixedUpdate()
    {
        if (_input.MovementDirection.magnitude != 0)
            Move(_input.MovementDirection);
        else
            _animation.StopMoving();

        if (_input.ShootingJoystickActive == true)
        {
            Rotation(new Vector3(_input.LookDirection.x, 0, _input.LookDirection.y));
            _animation.SetMovingInput(_input.MovementDirection.x, _input.MovementDirection.y);
        }
    }

    private void Move(Vector2 direction)
    {
        float targetAngle;
        Vector3 moveDirection;

        if (_camera == null)
            throw new ArgumentNullException("Camera is null");

        targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
        moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        _rigidbody.position += moveDirection.normalized * _speed * Time.deltaTime;

        if (_input.ShootingJoystickActive == false)
        {
            _animation.StartMoving();
            Rotation(moveDirection);
        }
    }

    private void Rotation(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
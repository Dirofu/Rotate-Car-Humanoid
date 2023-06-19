using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerAnimation : MonoBehaviour
{
    private PlayerInput _input;
    private Animator _animator;

    private const string _isMoving = "isMoving";
    private const string _isAiming = "isAiming";
    private const string _vertical = "Vertical";
    private const string _horizontal = "Horizontal";
    private const string _jump = "Jump";

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        SetBoolState(_isAiming, _input.ShootingJoystickActive);
    }

    public void SetMovingInput(float vertical, float horizontal)
    {
        SetFloatValue(_vertical, vertical);
        SetFloatValue(_horizontal, horizontal);
    }

    public void Jump() => SetTriggerState(_jump);
    public void StartMoving() => SetBoolState(_isMoving, true);
    public void StopMoving() => SetBoolState(_isMoving, false);

    private void SetFloatValue(string name, float value) => _animator.SetFloat(name, value);
    private void SetBoolState(string name, bool state) => _animator.SetBool(name, state);
    private void SetTriggerState(string name) => _animator.SetTrigger(name);
}
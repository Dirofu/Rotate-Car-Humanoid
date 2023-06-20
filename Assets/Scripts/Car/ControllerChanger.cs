using UnityEngine;

public class ControllerChanger : MonoBehaviour
{
    [SerializeField] private GameObject _buttonController;
    [SerializeField] private GameObject _joystickController;

    public void ChangeController()
    {
        _buttonController.SetActive(!_buttonController.activeInHierarchy);
        _joystickController.SetActive(!_joystickController.activeInHierarchy);
    }
}

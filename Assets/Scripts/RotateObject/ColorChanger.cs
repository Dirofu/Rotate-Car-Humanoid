using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] _colors;

    private MeshRenderer _renderer;
    private int _clickCount = -1;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickCount++;

            if (_clickCount >= _colors.Length)
                _clickCount = 0;

            _renderer.material.color = _colors[_clickCount];
        }
    }
}

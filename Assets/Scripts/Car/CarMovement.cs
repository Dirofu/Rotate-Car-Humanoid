using UnityEngine;

[RequireComponent(typeof(CarInput))]
public class CarMovement : MonoBehaviour 
{
	[SerializeField] private float _maxAngle = 30;
	[SerializeField] private float _maxTorque = 300;

	private WheelCollider[] _wheels;
	private CarInput _input;

	private Vector3 _localScale = new Vector3(1, 1, 1);

	private void Awake()
    {
		_input = GetComponent<CarInput>();
	}

    private void Start()
	{
		GameObject visual;

		_wheels = GetComponentsInChildren<WheelCollider>();

		for (int i = 0; i < _wheels.Length; ++i) 
		{
			visual = _wheels[i].GetComponentInChildren<MeshRenderer>().gameObject;
			visual.transform.parent = _wheels[i].transform;
		}
	}

	private void Update()
	{
		Drive();
	}

	private void Drive()
    {
		Quaternion wheelQuaternion;
		Vector3 wheelPosition;
		
		float angle = _maxAngle * _input.HorizontalValue;
		float torque = _maxTorque * _input.VerticalValue;

		foreach (WheelCollider wheel in _wheels)
		{
			if (wheel.transform.localPosition.z > 0)
				wheel.steerAngle = angle;

			if (wheel.transform.localPosition.z < 0)
				wheel.motorTorque = torque;

			wheel.GetWorldPose(out wheelPosition, out wheelQuaternion);

			Transform shapeTransform = wheel.transform.GetChild(0);
			shapeTransform.position = wheelPosition;
			shapeTransform.rotation = wheelQuaternion;
			shapeTransform.localScale = _localScale;
		}
	}
}

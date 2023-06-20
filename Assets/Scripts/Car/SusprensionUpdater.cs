using UnityEngine;

[ExecuteInEditMode()]
public class SusprensionUpdater : MonoBehaviour 
{
	[Range(0, 20)]
	[SerializeField] private float _naturalFrequency = 10;
	[Range(0, 3)]
	[SerializeField] private float _dampingRatio = 0.8f;
	[Range(-1, 1)]
	[SerializeField] private float _forceShift = 0.03f;

	[SerializeField] private bool _suspensionDistance = true;

	private int _springDegree = 2;

	private void Update () 
	{
		UpdateSuspension();
	}

	private void UpdateSuspension()
    {
		JointSpring spring;
		Vector3 wheelRelativeBody;
		float distance;

		foreach (WheelCollider wheel in GetComponentsInChildren<WheelCollider>())
		{
			spring = wheel.suspensionSpring;

			spring.spring = Mathf.Pow(Mathf.Sqrt(wheel.sprungMass) * _naturalFrequency, _springDegree);
			spring.damper = _springDegree * _dampingRatio * Mathf.Sqrt(spring.spring * wheel.sprungMass);

			wheel.suspensionSpring = spring;

			wheelRelativeBody = transform.InverseTransformPoint(wheel.transform.position);
			distance = GetComponent<Rigidbody>().centerOfMass.y - wheelRelativeBody.y + wheel.radius;

			wheel.forceAppPointDistance = distance - _forceShift;

			if (spring.targetPosition > 0 && _suspensionDistance)
				wheel.suspensionDistance = wheel.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
		}
	}
}
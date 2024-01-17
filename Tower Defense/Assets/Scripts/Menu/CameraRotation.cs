using System.Collections;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	public float RotationSpeed = 0.05f;
	public void RotateOnYAxis(float targetAngle)
	{
		Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetAngle, transform.rotation.eulerAngles.z);
		StartCoroutine(Rotate(targetRotation, RotationSpeed));
	}

	IEnumerator Rotate(Quaternion targetRotation, float rotationSpeed)
	{
		while (transform.rotation != targetRotation)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,rotationSpeed);
			yield return 0;
		}
	}
}

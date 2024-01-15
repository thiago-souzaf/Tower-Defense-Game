using UnityEngine;

public class StudioCamera : MonoBehaviour
{
	public float rotationSpeed = 15f;
	private float horizontalDirection;

    private void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        transform.Rotate(horizontalDirection * rotationSpeed * Vector3.up);
    }
}

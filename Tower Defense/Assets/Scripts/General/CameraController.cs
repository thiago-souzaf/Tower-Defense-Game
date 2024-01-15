using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Pan Properties")]
    public float panSpeed = 30f;
    public float horizontalRange = 35f;
    public float verticalMin = -50f;
    public float verticalMax = 20f;

    [Header("Scroll Properties")]
    public float scrollSpeed = 5f;
    public float minHeight = 10f;
    public float maxHeight = 65f;
    public float maxRotation = 70f;

    private Vector3 pos;
    private Quaternion rot;

    void Update()
    {

        if (GameManager.isGameOver)
        { 
            this.enabled = false;
            return;
        }
        
        pos = transform.position;

        // Pan movement
        pos.x += Input.GetAxisRaw("Horizontal") * panSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -horizontalRange, horizontalRange);

        pos.z += Input.GetAxisRaw("Vertical") * panSpeed * Time.deltaTime;
        pos.z = Mathf.Clamp(pos.z, verticalMin, verticalMax);

        // Scroll movement
        pos.y -= Input.GetAxisRaw("Mouse ScrollWheel") * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);

        // Rotation on scrolling
        float rot_x = Mathf.Clamp(pos.y, 0f, maxRotation);
        rot = Quaternion.Euler(rot_x, 0, 0) ;

        transform.SetPositionAndRotation(pos, rot);
    }
}

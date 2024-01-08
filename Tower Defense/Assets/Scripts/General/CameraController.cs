using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Pan Properties")]
    public float panSpeed = 30f;
    public float horizontalRange;
    public float verticalRange;
    
    [Header("Scroll Properties")]
    public float scrollSpeed = 5f;
    public float minHeight = 10f;
    public float maxHeight = 65f;

    void Update()
    {

        if (GameManager.isGameOver)
        { 
            this.enabled = false;
            return;
        }
        
        Vector3 pos = transform.position;

        // Pan movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        pos.x += horizontal * panSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -horizontalRange, horizontalRange);

        float vertical = Input.GetAxisRaw("Vertical");
        pos.z += vertical * panSpeed * Time.deltaTime;
        pos.z = Mathf.Clamp(pos.z, -verticalRange, verticalRange);

        // Scroll movement
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);


        transform.position = pos;
    }
}

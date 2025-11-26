using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // The Spider
    public float distance = 8.0f;  // How far back
    public float height = 4.0f;    // How high up
    public float rotationSpeed = 5.0f; // Mouse sensitivity

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void Start()
    {
        // Optional: Hide the cursor so it doesn't annoy you
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. Get Mouse Input
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        // 2. Clamp the Up/Down rotation so you can't flip upside down
        currentY = Mathf.Clamp(currentY, -10, 60);
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 3. Calculate Rotation based on Mouse
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // 4. Calculate Position (Orbit around target)
        // (We calculate position by taking the rotation and backing up by 'distance')
        Vector3 direction = new Vector3(0, 0, -distance);
        Vector3 position = target.position + (Vector3.up * height) + (rotation * direction);

        // 5. Apply
        transform.position = position;
        transform.LookAt(target.position + Vector3.up * (height * 0.5f)); // Look slightly above the feet
    }
}
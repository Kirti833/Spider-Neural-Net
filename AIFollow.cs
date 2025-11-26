using UnityEngine;

public class AIFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 5, -8); // Up 5, Back 8
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null) return;

        // FIX: Use TransformPoint to convert (0, 5, -8) from "Local" to "World" space
        // This keeps the camera locked to the spider's rotation (Behind it)
        Vector3 desiredPosition = target.TransformPoint(offset);
        
        // Smoothly slide there
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Always look at the spider
        transform.LookAt(target);
    }
}
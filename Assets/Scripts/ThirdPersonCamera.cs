using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;              // drag Player here
    public float distance = 5f;           // how far behind the player
    public float height = 2f;             // how high above the player
    public float mouseSensitivity = 3f;
    public float smoothSpeed = 10f;
    public float minPitch = -20f;
    public float maxPitch = 60f;

    private float yaw = 0f;
    private float pitch = 15f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // hide + lock cursor
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Mouse input
        yaw   += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch  = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Calculate camera position
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        Vector3 desiredPos = target.position + Vector3.up * height + offset;

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * height);
    }
}
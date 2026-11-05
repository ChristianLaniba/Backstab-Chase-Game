using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform;   // drag Main Camera here
    public float rotationSpeed = 12f;

    private CharacterController cc;

    void Start() => cc = GetComponent<CharacterController>();

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        // Camera-relative direction
        Vector3 forward = cameraTransform.forward;
        Vector3 right   = cameraTransform.right;
        forward.y = 0f;
        right.y   = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 move = (forward * v + right * h);

        if (move.magnitude > 0.1f)
        {
            cc.Move(move.normalized * speed * Time.deltaTime);

            // Rotate player to face movement direction
            Quaternion targetRot = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }
}
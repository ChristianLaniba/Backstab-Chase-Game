using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController cc;

    void Start() => cc = GetComponent<CharacterController>();

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S
        Vector3 move = new Vector3(h, 0, v);
        cc.Move(move * speed * Time.deltaTime);

        if (move != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(move);
    }
}
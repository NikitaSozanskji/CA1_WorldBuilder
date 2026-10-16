using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce = 7f;

    public Transform camera;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Prevent the player from tipping over
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Get WASD input
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Use camera direction, ignoring up/down tilt
        Vector3 forward = camera.forward;
        Vector3 right = camera.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 20f; // Sprinting speed
        }
        else
        {
            moveSpeed = 5f; // Normal speed
        }

        Vector3 movement = (forward * z + right * x).normalized;

        // Move while preserving vertical velocity
        Vector3 velocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(
            movement.x * moveSpeed,
            velocity.y,
            movement.z * moveSpeed
        );

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
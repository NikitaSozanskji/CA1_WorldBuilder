using UnityEngine;

public class player : MonoBehaviour
{
    public AudioClip Walk;
    public AudioSource walkAudio;

    public float moveSpeed;
    public float jumpForce = 7f;

    public Transform camera;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        walkAudio.clip = Walk;
        walkAudio.loop = true;
        walkAudio.playOnAwake = false;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 forward = camera.forward;
        Vector3 right = camera.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 30f;
        }
        else
        {
            moveSpeed = 15f;
        }

        Vector3 movement = (forward * z + right * x).normalized;

        Vector3 velocity = rb.linearVelocity;

        rb.linearVelocity = new Vector3(
            movement.x * moveSpeed,
            velocity.y,
            movement.z * moveSpeed
        );

        bool isMoving = x != 0 || z != 0;

        if (isMoving && isGrounded)
        {
            if (!walkAudio.isPlaying)
            {
                walkAudio.Play();
            }
        }
        else
        {
            if (walkAudio.isPlaying)
            {
                walkAudio.Stop();
            }
        }
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
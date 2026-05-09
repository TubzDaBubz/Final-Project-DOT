using UnityEngine;

public class TopDownPlayer3d : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized; // prevents faster diagonal movement
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
    }
}
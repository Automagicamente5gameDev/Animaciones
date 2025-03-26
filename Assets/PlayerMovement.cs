using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;      // Velocidad de movimiento
    public float jumpForce = 7f;  // Fuerza del salto
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento lateral
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        Debug.Log(isGrounded);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // Evita saltos dobles
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si tocamos el suelo, permitimos volver a saltar
        if (collision.gameObject.name == "Plataforma")
        {
            isGrounded = true;
        }
    }
}

using UnityEngine;

public class _PlayerJump : MonoBehaviour
{
    [Header("Configuración de Salto")]
    // Fuerza de salto
    [SerializeField] private float jumpForce = 14f;
    // Hacer que caiga mas Rapido
    [SerializeField] private float fallingForce = 3f;
    // campo para ubicar el gameObject de Salto
    [SerializeField] private Transform groundPosition; 
    // longitud del raycast base del jugador
    [SerializeField] private float raycastLength = 1.05f; 
    // Identificar que elementos tienen el layer de suelo
    [SerializeField] private LayerMask groundLayer;
    private bool onGround;
    

    // Controlador del Jump Buffer
    private float jumpBufferTime = 0.1f; 
    private float jumpBufferCounter;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
    }

    void Update()
    {
        // Detectamos el suelo
        RaycastHit2D hit = Physics2D.Raycast(groundPosition.position, Vector2.left, raycastLength, groundLayer);
        onGround = hit.collider != null;

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && onGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpBufferCounter = 0f; 
        }
        // Se aplica una fuerza ligeramente mayor para obligar al jugador a caer
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    void FixedUpdate()
    {
        // Se aplica una fuerza extra cuando cae el jugador
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallingForce - 1) * Time.fixedDeltaTime;
        }
    }

    // visualizar el raycast de salto (no necesario)
    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(groundPosition.position, groundPosition.position + Vector3.left * raycastLength);
    // }
}

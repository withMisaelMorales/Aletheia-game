using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento X")]
    [SerializeField] private float speed = 11f;

    [Header("Configuración de Salto")]
    [SerializeField] private Transform positionInit;
    [SerializeField] private float fuerzaSalto = 14f;
    // IMPORTANTE: Si el rayo sale del centro, debe ser mayor a la mitad de tu personaje
    [SerializeField] private float longitudRayCast = -1f; 
    [SerializeField] private float multiplicadorCaida = 3f; // Cuanto más alto, más rápido cae
    [SerializeField] private LayerMask capaSuelo;
    private bool enSuelo;

    [SerializeField] private float jumpBufferTime = 0.1f; 
    private float jumpBufferCounter;

    private Rigidbody2D rb;
    private float moveX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
    }

    void Update()
    {
        // 1. Solo leemos el eje X para caminar
        moveX = Input.GetAxisRaw("Horizontal");

        // 2. Detección de suelo mejorada
        RaycastHit2D hit = Physics2D.Raycast(positionInit.position, Vector2.left, longitudRayCast, capaSuelo);
        enSuelo = hit.collider != null;

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Limpieza recomendada para el buffer
            //rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            jumpBufferCounter = 0f; // Resetear buffer tras saltar
        }
    }

    void FixedUpdate()
    {
        // 4. Movimiento Horizontal (Es mejor usar velocity para dejar que la gravedad actúe)
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if (rb.linearVelocity.y < 0)
        {
            // Aplicamos una fuerza extra hacia abajo
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (multiplicadorCaida - 1) * Time.fixedDeltaTime;
        }
    }

    // CORRECCIÓN: El método correcto es OnDrawGizmos
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(positionInit.position, positionInit.position + Vector3.left * longitudRayCast);
    }
}
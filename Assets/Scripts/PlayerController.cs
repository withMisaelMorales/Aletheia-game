using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento X")]
    [SerializeField] private float speed = 10f;

    [Header("Configuración de Salto")]
    [SerializeField] private Transform positionInit;
    [SerializeField] private float fuerzaSalto = 12f;
    // IMPORTANTE: Si el rayo sale del centro, debe ser mayor a la mitad de tu personaje
    [SerializeField] private float longitudRayCast = 0.1f; 
    [SerializeField] private LayerMask capaSuelo;
    private bool enSuelo;

    private Rigidbody2D rb;
    private float moveX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Solo leemos el eje X para caminar
        moveX = Input.GetAxisRaw("Horizontal");

        // 2. Detección de suelo mejorada
        RaycastHit2D hit = Physics2D.Raycast(positionInit.position, Vector2.down, longitudRayCast, capaSuelo);
        enSuelo = hit.collider != null;

        // 3. Salto (Usamos GetButtonDown para mayor respuesta)
        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            // Limpiamos la velocidad vertical antes de saltar para que siempre suba igual
            //rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // 4. Movimiento Horizontal (Es mejor usar velocity para dejar que la gravedad actúe)
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }

    // CORRECCIÓN: El método correcto es OnDrawGizmos
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(positionInit.position, positionInit.position + Vector3.down * longitudRayCast);
    }
}
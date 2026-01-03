using UnityEngine;

public class _PlayerControllerX : MonoBehaviour
{
    [Header("Configuración de Movimiento X")]
    [SerializeField] private float speedPlayer = 10f;
    private Rigidbody2D rb;
    private float movementX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementX * speedPlayer, rb.linearVelocity.y);
    }
}

using UnityEngine;

public class _PlayerControllerX : MonoBehaviour
{
    private const string STRING_VELOCIDAD_HORIZONTAL = "velocidadX";
    private _PlayerJump jumpScript;
    [Header("Configuración de Movimiento X")]
    [SerializeField] private float speedPlayer = 10f;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    private float movementX;
    private bool mirandoDerecha = true;
    [SerializeField] private Transform playerVisual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpScript = GetComponent<_PlayerJump>();
    }

    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        controlAnimator();
        Flip(movementX);

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementX * speedPlayer, rb.linearVelocity.y);
    }

    void controlAnimator() {
        animator.SetFloat(STRING_VELOCIDAD_HORIZONTAL, Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("suelo", jumpScript.onGround);
    }
void Flip(float horizontal)
    {
        // Solo actuamos si hay movimiento (horizontal != 0)
        if (horizontal > 0 && !mirandoDerecha)
        {
            mirandoDerecha = true;
            RotarHijo(0);
        }
        else if (horizontal < 0 && mirandoDerecha)
        {
            mirandoDerecha = false;
            RotarHijo(180);
        }
    }

    void RotarHijo(float angulo)
    {
        // En lugar de escalar, rotamos el objeto visual sobre el eje Y
        // Esto es más limpio para jerarquías complejas
        playerVisual.localRotation = Quaternion.Euler(0, angulo, 0);
    }
}

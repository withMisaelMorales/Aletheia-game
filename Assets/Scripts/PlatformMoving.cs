using UnityEngine;

public class SueloInfinito : MonoBehaviour
{
    [SerializeField] private float velocidadSubida = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Calculamos la nueva posición sumando un poco hacia arriba en cada frame
        Vector2 nuevaPos = rb.position + Vector2.up * velocidadSubida * Time.fixedDeltaTime;
        
        // Movemos el Rigidbody
        rb.MovePosition(nuevaPos);
    }
}
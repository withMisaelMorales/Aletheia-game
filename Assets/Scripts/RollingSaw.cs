using UnityEngine;

public class MovimientoSimple : MonoBehaviour
{
    public float distancia = 3f; // Qué tan lejos llega
    public float velocidad = 2f; // Qué tan rápido se mueve
    private Vector3 posicionInicial;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;
    }    
}
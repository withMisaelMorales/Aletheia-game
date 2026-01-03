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

    // void Update()
    // {
    //     // Al usar timeSinceLevelLoad, el movimiento siempre empieza desde el "segundo 0"
    //     float movimiento = Mathf.PingPong(Time.timeSinceLevelLoad * velocidad, distancia);
    //     transform.position = new Vector3(posicionInicial.x + movimiento, posicionInicial.y, posicionInicial.z);
    //     transform.Rotate(Vector3.forward * 900F* Time.fixedDeltaTime);
    // }
    // void FixedUpdate()
    // {
    //     float movimiento = Mathf.PingPong(Time.timeSinceLevelLoad * velocidad, distancia);
    //     Vector2 nuevaPos = new Vector2(posicionInicial.x + movimiento, posicionInicial.y);
        
    //     // Movemos el Rigidbody
    //     rb.MovePosition(nuevaPos);
    // }    
}
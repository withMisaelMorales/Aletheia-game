using UnityEngine;

public class MovimientoSimple : MonoBehaviour
{
    public float distancia = 3f; // Qué tan lejos llega
    public float velocidad = 2f; // Qué tan rápido se mueve
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }
    void FixedUpdate()
    {
        // Al usar timeSinceLevelLoad, el movimiento siempre empieza desde el "segundo 0"
        float movimiento = Mathf.PingPong(Time.timeSinceLevelLoad * velocidad, distancia);
        transform.position = new Vector3(posicionInicial.x + movimiento, posicionInicial.y, posicionInicial.z);
        transform.Rotate(Vector3.forward * 300F* Time.fixedDeltaTime);
    }
}
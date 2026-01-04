using UnityEngine;

public class _MovementXY : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
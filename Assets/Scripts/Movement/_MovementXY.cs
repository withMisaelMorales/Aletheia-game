using UnityEngine;

public class _MovementXY : MonoBehaviour
{
    public enum MovementDirection { Horizontal, Vertical }

    [Header("Configuración de Selección")]
    [SerializeField] private MovementDirection direccion = MovementDirection.Horizontal;

    [Header("Ajustes de Movimiento")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 3f;

    private Vector3 startPos;

    void Start()
    {
        // Guardamos la posición inicial como punto de anclaje
        startPos = transform.position;
    }

    void Update()
    {
        // Calculamos el valor de oscilación
        float movement = Mathf.PingPong(Time.time * speed, distance) - (distance / 2f);

        // Aplicamos el movimiento basado en la elección del Enum
        if (direccion == MovementDirection.Horizontal)
        {
            transform.position = new Vector3(startPos.x + movement, startPos.y, startPos.z);
        }
        else if (direccion == MovementDirection.Vertical)
        {
            transform.position = new Vector3(startPos.x, startPos.y + movement, startPos.z);
        }
    }  
}


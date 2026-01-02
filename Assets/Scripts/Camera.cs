using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    [SerializeField] private Transform objetivo; // Tu Player
    [SerializeField] private float suavizado = 0.125f; // Cuanto más bajo, más elástica la cámara    
    [SerializeField] private Vector3 desfasePersonalizado = new Vector3(0, 1, -10);

    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Sumamos el desfase a la posición del jugador
            // Pero mantenemos la X de la cámara fija
            float xFija = transform.position.x;
            float ySeguimiento = objetivo.position.y + desfasePersonalizado.y;
            float zSeguimiento = desfasePersonalizado.z;

            Vector3 posicionDeseada = new Vector3(xFija, ySeguimiento, zSeguimiento);
            
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado);
        }
    }
}
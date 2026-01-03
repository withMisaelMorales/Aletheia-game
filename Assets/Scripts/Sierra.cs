using UnityEngine;

public class Sierra : MonoBehaviour
{
    // Esta función se activa cuando la sierra sale de TODAS las cámaras
    private void OnBecameInvisible()
    {
        // La destruimos para liberar memoria
        Destroy(gameObject);
    }
}
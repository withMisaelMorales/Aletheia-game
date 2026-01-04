using UnityEngine;

public class _DespawnerObject : MonoBehaviour
{
    private float margin = 0.2f; 
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        CheckIfOffScreen();
    }

    void CheckIfOffScreen()
    {
        // Convertimos la posición a coordenadas de cámara (0 a 1)
        Vector3 screenPoint = mainCam.WorldToViewportPoint(transform.position);

        // Verificamos si está fuera usando el margen
        // -margin es un poco a la izquierda/abajo, 1+margin es un poco a la derecha/arriba
        bool isOffScreen = screenPoint.x < -margin || screenPoint.x > 1 + margin || 
                           screenPoint.y < -margin || screenPoint.y > 1 + margin;

        if (isOffScreen)
        {
            Destroy(gameObject);
        }
    }
}

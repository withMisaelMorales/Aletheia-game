using UnityEngine;

public class SpawnSaw : MonoBehaviour
{
    public GameObject sierraPrefab; // Arrastra aquí el prefab de la sierra
    public float tiempoEntreSierras = 3f;

    void Start()
    {
        // Genera una sierra cada X segundos de forma infinita
        InvokeRepeating("Spawn", 0f, tiempoEntreSierras);
    }

    void Spawn()
    {
        Instantiate(sierraPrefab, transform.position, Quaternion.identity);
    }
}
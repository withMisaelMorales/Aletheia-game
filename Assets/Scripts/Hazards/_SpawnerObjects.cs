using UnityEngine;

public class _SpawnerObjects : MonoBehaviour
{
    // posicion del spawner
    [SerializeField] private Transform spawnPoint;
    // prefab a generar
    [SerializeField] private GameObject prefabObject;
    // tiempo entre elemento
    public float timeBetweenObjects = 3f;

    void Start()
    {
        InvokeRepeating("Spawn", 0f, timeBetweenObjects);
    }

    void Spawn()
    {
        if (spawnPoint != null)
        {
            Instantiate(prefabObject, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Instantiate(prefabObject, transform.position, Quaternion.identity);
        }
    }
}

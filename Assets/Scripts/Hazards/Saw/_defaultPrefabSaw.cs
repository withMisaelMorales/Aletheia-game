using UnityEngine;

public class _defaultPrefabSaw : MonoBehaviour
{

    // Definimos los modos que queremos permitir
    public enum BodyTypeChoice { Dynamic, Kinematic }

    [Header("Configuración General")]
    [SerializeField] private float rotationSpeed = 100f;    
    [Header("Configuración de Físicas")]
    [SerializeField] private BodyTypeChoice typeRigiBody = BodyTypeChoice.Dynamic;    
    private float escalaGravedad = 2.31f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        changeMode();
    }

    void Update()
    {
        // solo rotar objeto
        transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
    }

    void changeMode()
    {
        if (typeRigiBody == BodyTypeChoice.Dynamic)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = escalaGravedad;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    // Esto permite que si cambias la opción en el Inspector mientras juegas, se actualice
    void OnValidate()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        changeMode();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser2D : MonoBehaviour
{
    public enum LaserDirection { Derecha, Izquierda, Arriba, Abajo }
    [SerializeField] private LaserDirection directionLaser = LaserDirection.Derecha;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public float distance = 50f;
    [SerializeField] private LayerMask groundLayer;
    public BoxCollider2D laserCollider;

    void Start()
    {
        // Si no lo asignaste en el inspector, lo busca solo
        if (lineRenderer == null) lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {        

        Vector2 vectorDirection = Vector2.right;
        switch(directionLaser)
        {
            case LaserDirection.Derecha: vectorDirection = firePoint.right; break;
            case LaserDirection.Arriba: vectorDirection = firePoint.up; break;
            case LaserDirection.Izquierda: vectorDirection = -firePoint.right; break;
            case LaserDirection.Abajo: vectorDirection = -firePoint.up; break;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        
        Vector3 finalPoint;

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, vectorDirection, distance, groundLayer);

        if (hit.collider != null)
        {
            finalPoint = hit.point;
        }
        else
        {
            finalPoint = firePoint.position + (Vector3)vectorDirection * distance;
        }
        
        lineRenderer.SetPosition(1, finalPoint);       
        
        UpdateLaserCollider(firePoint.position, finalPoint);        
    }

    void UpdateLaserCollider(Vector3 startPos, Vector3 endPos)
    {
        float laserDistance = Vector3.Distance(startPos, endPos);
        laserCollider.size = new Vector2(laserDistance, 0.1f);

        // Posicionamiento
        Vector3 midPoint = (startPos + endPos) / 2f;
        laserCollider.transform.position = midPoint;

        // Rotación
        float angle = Mathf.Atan2(endPos.y - startPos.y, endPos.x - startPos.x) * Mathf.Rad2Deg;
        laserCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
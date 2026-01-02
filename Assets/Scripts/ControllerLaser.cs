using UnityEngine;

public class Laser2D : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform firePoint; // El origen del láser
    public float distance = 50f;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {        
        lineRenderer.SetPosition(0, firePoint.position);

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, distance, groundLayer);

        if (hit.collider != null)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * distance);
        }
    }
    
}
using UnityEngine;

public class _platformLava : MonoBehaviour
{
    [SerializeField] private float speedUp = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 positionY = rb.position + Vector2.up * speedUp * Time.fixedDeltaTime;
        rb.MovePosition(positionY);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class _PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("destroyer"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("destroyer"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }        
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("destroyer"))
        {
            // Destruye el bloque
            Destroy(gameObject);
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
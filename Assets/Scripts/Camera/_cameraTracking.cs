using UnityEngine;

public class _cameraTracking : MonoBehaviour
{
    [SerializeField] private Transform gameObjectPlayer;
    [SerializeField] private float smooth = 0.125f;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 1, -10);

    void LateUpdate()
    {
        if (gameObjectPlayer != null)
        {
            // posicion camara
            Vector3 posicionDeseada = new Vector3(
                transform.position.x, 
                gameObjectPlayer.position.y + cameraOffset.y, 
                cameraOffset.z
            );            
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, smooth);
        }
    }
}
using Unity.VisualScripting;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<GameOverTrigger>(out var gameOverTrigger))
        {
            gameOverTrigger.GameOverOn();
        }
        Destroy(gameObject);
    }
}

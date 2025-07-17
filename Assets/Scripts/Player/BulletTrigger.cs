using Unity.VisualScripting;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<GameOverTrigger>(out var gameOverTrigger)
        && collision.TryGetComponent<AnimatorController>(out var animatorController))
        {
            animatorController.Death();
            gameOverTrigger.GameOverOn();
        }
        Destroy(gameObject);
    }
}

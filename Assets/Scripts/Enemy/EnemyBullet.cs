using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    void Start()
    {
        Destroy(gameObject, 1);
    }

    void Update()
    {
        transform.Translate(Vector2.left * bulletSpeed * Time.deltaTime);
    }
}

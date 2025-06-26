using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _destroyEffect;
    [SerializeField] private GameObject _bloodSplash;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector2)(transform.right * _speed * Time.fixedDeltaTime));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DamageAccept>(out var damageAccept))
        {
            damageAccept.DeathStart();
        }
        Destroy(gameObject);
    }

    void DestroyBullet()
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity);
        Instantiate(_bloodSplash, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

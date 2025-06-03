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

    void Update()
    {
        Destroy(gameObject, 2);

        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DamageAccept>(out var damageAccept))
        {
            damageAccept.DeathStart();
            Destroy(gameObject);
            Debug.Log("Dead");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void DestroyBullet()
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity);
        Instantiate(_bloodSplash, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

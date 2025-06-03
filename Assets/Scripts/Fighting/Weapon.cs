using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer gunSprite;
    [SerializeField] private Transform _point;
    [SerializeField] private Transform flintlock;
    [SerializeField] private GameObject _bullet;
    [Header("Parameters")]
    [SerializeField] private float _offset;
    [SerializeField] private float _startTime;
    [SerializeField] private int _ammo;
    private float _time;

    void Update()
    {
        Rotates();

        Shoot();
    }

    private void Shoot()
    {
        if (_time <= 0f)
        {
            if (Input.GetMouseButtonDown(0) && _ammo > 0)
            {
                Instantiate(_bullet, _point.position, transform.rotation);
                _time = _startTime;
                _ammo--;
            }
        }
        else
        {
            _time -= Time.deltaTime;
        }
    }

    private void Rotates()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);

        if (rotateZ > 90)
        {
            flintlock.localScale = new Vector3(0.05554573f, -0.05554573f, 0.05554573f);
            head.flipX = true;
        }

        if (rotateZ < 90)
        {
            flintlock.localScale = new Vector3(0.05554573f, 0.05554573f, 0.05554573f);
            head.flipX = false;
        }

        if (rotateZ < -90)
        {
            flintlock.localScale = new Vector3(0.05554573f, -0.05554573f, 0.05554573f);
            head.flipX = true;
        }
    }
}

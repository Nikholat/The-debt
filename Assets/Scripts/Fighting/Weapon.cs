using UnityEngine.UI;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer gunSprite;
    [SerializeField] private Transform _point;
    [SerializeField] private Transform flintlock;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GunAnimation gunAnim;

    [Header("UI Bullets Control")]
    [SerializeField] private GameObject[] _bullets;
    [SerializeField] private Sprite shotedBullet;
    [SerializeField] private Sprite newBullet;

    [Header("Parameters")]
    [SerializeField] private float _offset;
    [SerializeField] private float _startTime;
    [SerializeField] private int _ammo;
    private float _time;

    void Update()
    {
        Rotates();

        Shoot();

        SwapBulletsSystem();
    }

    private void Shoot()
    {
        if (_time <= 0f)
        {
            if (Input.GetMouseButtonDown(0) && _ammo > 0)
            {
                gunAnim.ShootAnim();
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

    private void SwapBulletsSystem()
    {
        if (_ammo <= 0)
        {
            _bullets[4].GetComponent<Image>().sprite = shotedBullet;
        }
        else
        {
            _bullets[4].GetComponent<Image>().sprite = newBullet;
        }

        if (_ammo <= 1)
        {
            _bullets[3].GetComponent<Image>().sprite = shotedBullet;
        }
        else
        {
            _bullets[3].GetComponent<Image>().sprite = newBullet;
        }

        if (_ammo <= 2)
        {
            _bullets[2].GetComponent<Image>().sprite = shotedBullet;
        }
        else
        {
            _bullets[2].GetComponent<Image>().sprite = newBullet;
        }

        if (_ammo <= 3)
        {
            _bullets[1].GetComponent<Image>().sprite = shotedBullet;
        }
        else
        {
            _bullets[1].GetComponent<Image>().sprite = newBullet;
        }

        if (_ammo <= 4)
        {
            _bullets[0].GetComponent<Image>().sprite = shotedBullet;
        }
        else
        {
            _bullets[0].GetComponent<Image>().sprite = newBullet;
        }
    }

    public void AmmoGive()
    {
        _ammo += 1;
        if (_ammo >= 5)
            _ammo = 5;
    }
}

using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float maxReloadTime;
    [SerializeField] float rayDistance;
    private float currentReloadTime;
    private bool canShoot;
    private void Update()
    {
        // Перезарядка
        currentReloadTime -= Time.deltaTime;
        if (currentReloadTime <= 0)
        {
            canShoot = true;
            currentReloadTime = maxReloadTime;
        }
        else
        {
            canShoot = false;
        }
        // Выстрел
        RaycastHit2D hit = Physics2D.Raycast(gunPoint.position, -Vector2.right, rayDistance);

        Debug.DrawRay(gunPoint.position, -Vector2.right * rayDistance, Color.white, 10000f);

        // if (hit.transform.CompareTag("Player"))
        // {
        //     // GameObject bullet = Instantiate(bulletPrefab, gunPoint.position,
        //     // bulletPrefab.transform.rotation);
        //     // bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left
        //     // * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
        //     // canShoot = false;
        //     Debug.Log("SeePlayer");
        // }
     
        if (canShoot)
        {
            if (hit.transform.CompareTag("Player"))
            {
                Instantiate(bulletPrefab, gunPoint.position, bulletPrefab.transform.rotation);

                canShoot = false;
                //Debug.Log("SeePlayer");
            }
        }

    }
}

using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunPoint;
    [SerializeField] private Transform arms;
    [SerializeField] private Transform head;
    [SerializeField] private Transform colliders;
    [SerializeField] private EnemyAnimatorController enemyAnims;
    [SerializeField] private PlayerTriggerSounds playerTriggerSounds;
    [SerializeField] private GunAnimation gunAnim;
    [SerializeField] float maxReloadTime;
    [SerializeField] float rayDistance;
    private bool isCrouch = false;
    private float currentReloadTime;
    private bool canShoot;
    private void Update()
    {
        if (enemyAnims.isDead == false)
        {
            if (isCrouch == false)
            {
                Invoke("CrouchEnable", 2);
            }
            if (isCrouch == true)
            {
                Invoke("CrouchDisable", 5);
            }
        }

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

        if (canShoot && !enemyAnims.isDead)
        {
            if (hit.transform != null && hit.transform.CompareTag("Player"))
            {
                playerTriggerSounds.ShootSound();

                Instantiate(bulletPrefab, gunPoint.position, bulletPrefab.transform.rotation);
                gunAnim.ShootAnim();

                canShoot = false;
                //Debug.Log("SeePlayer");
            }

        }

    }

    private void CrouchEnable()
    {
        if (enemyAnims.isDead == false)
        {
            enemyAnims.CrouchingTrue();
            arms.transform.localPosition = new Vector2(-0.107f, -0.366f);
            head.transform.localPosition = new Vector2(-0.23f, -0.505f);
            colliders.transform.localPosition = new Vector2(-0.15f, -0.353f);
            isCrouch = true;
        }
    }

    private void CrouchDisable()
    {
        if (enemyAnims.isDead == false)
        {
            enemyAnims.CrouchingFalse();
            arms.transform.localPosition = new Vector2(-0.026f, 0.065f);
            head.transform.localPosition = new Vector2(0.001999855f, -0.06900001f);
            colliders.transform.localPosition = new Vector2(0f, 0f);
            isCrouch = false;
        }
    }
}

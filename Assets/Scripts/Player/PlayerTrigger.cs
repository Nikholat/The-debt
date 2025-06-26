using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private RoadSpawner roadSpawner;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            weapon.AmmoGive();
            Debug.Log("AmmoTake");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Road"))
        {
            roadSpawner.Spawn();
        }
    }
}

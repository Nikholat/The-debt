using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private RoadSpawner roadSpawner;
    [SerializeField] private PlayerTriggerSounds playerTriggerSounds;

    void Start()
    {
        playerTriggerSounds = GetComponent<PlayerTriggerSounds>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            playerTriggerSounds.AmmoTakeOn();
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

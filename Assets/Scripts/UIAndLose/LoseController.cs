using UnityEngine;

public class LoseController : MonoBehaviour
{
    [SerializeField] Collider2D playerCollider;
    [SerializeField] Collider2D deathCollider;
    [SerializeField] GameObject playerArmsNHead;
    PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void DeathControl()
    {
        playerArmsNHead.SetActive(false);
        playerCollider.enabled = false;
        deathCollider.enabled = true;
        playerController.enabled = false;
    }

}

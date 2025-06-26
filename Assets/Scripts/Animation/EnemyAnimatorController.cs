using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField] private GameObject[] gunNHead;
    [SerializeField] private Animator animator;
    public bool isDead = false;
    private Ammo ammo;

    void Start()
    {
        ammo = GetComponent<Ammo>();
    }

    public void Death(string paramName)
    {
        animator.SetBool(paramName, true);
        for (int i = 0; i < gunNHead.Length; i++)
        {
            gunNHead[i].SetActive(false);
        }
        ammo.AmmoCreate();
        isDead = true;
        CrouchingFalse();
    }

    public void CrouchingTrue()
    {
        animator.SetBool("isCrouch", true);
    }

    public void CrouchingFalse()
    {
        animator.SetBool("isCrouch", false);
    }
}

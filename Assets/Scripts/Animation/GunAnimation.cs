using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ShootAnim()
    {
        animator.SetTrigger("Shoot");
    }
}

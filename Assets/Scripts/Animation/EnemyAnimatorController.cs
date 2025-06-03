using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField] private GameObject[] gunNHead;

    [SerializeField] private Animator animator;

    public void Death(string paramName)
    {
        animator.SetBool(paramName, true);
        for (int i = 0; i < gunNHead.Length; i++)
        {
            gunNHead[i].SetActive(false);
        }
    }
}

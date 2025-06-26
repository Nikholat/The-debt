using UnityEngine;

public class DamageAccept : MonoBehaviour
{
    [SerializeField] private EnemyAnimatorController enemyAnim;
    [SerializeField] private string paramName;

    public void DeathStart()
    {
        enemyAnim.Death(paramName);
        if (ScoreController.Instance != null)
        {
            ScoreController.Instance.DeathScorePlus();
        }
    }
}

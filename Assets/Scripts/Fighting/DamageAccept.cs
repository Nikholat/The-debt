using UnityEngine;

public class DamageAccept : MonoBehaviour
{
    [SerializeField] private EnemyAnimatorController enemyAnim;
    [SerializeField] private string paramName;
    private ScoreController scoreController;

    void Awake()
    {
        scoreController = FindAnyObjectByType<ScoreController>();
    }

    public void DeathStart()
    {
        enemyAnim.Death(paramName);
        scoreController.DeathScorePlus();
    }
}

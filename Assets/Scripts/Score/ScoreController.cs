using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deathCount;
    [SerializeField] private TextMeshProUGUI deathCountOnUI;
    private int deathScore;

    void Update()
    {
        Debug.Log("Death Score - " + deathScore);
    }

    public void DeathScorePlus()
    {
        deathScore += 1;
        deathCount.text = deathScore.ToString();
    }

    public void UpdateDeathScore()
    {
        deathCountOnUI.text = deathScore.ToString();
    }
}

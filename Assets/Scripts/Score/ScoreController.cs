using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deathCount;
    private int deathScore;
    public static ScoreController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Debug.Log("Death Score - " + deathScore);
    }

    public void DeathScorePlus()
    {
        deathScore += 1;
        deathCount.text = deathScore.ToString();
    }
}

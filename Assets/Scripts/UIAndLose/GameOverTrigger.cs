using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private ScoreController scoreController;
    private PlayerTriggerSounds playerTriggerSounds;

    void Start()
    {
        playerTriggerSounds = GetComponent<PlayerTriggerSounds>();
    }

    public void GameOverOn()
    {
        Invoke("GameOverMenuOn", 4f);
        playerTriggerSounds.PlayGameOverSound();
    }

    private void GameOverMenuOn()
    {
        scoreController.UpdateDeathScore();
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}

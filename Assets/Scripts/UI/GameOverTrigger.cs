using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;

    public void GameOverOn()
    {
        gameOverMenu.SetActive(true);
    }
}

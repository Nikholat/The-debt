using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject player;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Pause()
    {
        player.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        player.SetActive(true);
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}

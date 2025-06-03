using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}

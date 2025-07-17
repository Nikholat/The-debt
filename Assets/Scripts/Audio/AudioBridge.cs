using UnityEngine;

public class AudioBridge : MonoBehaviour
{
    [SerializeField] private GameObject gameAmbient;
    [SerializeField] private GameObject loseAmbient;
   
    public void LoseAmbientStartOn()
    {
        loseAmbient.SetActive(true);
    }

    public void GameAmbientSoundOff()
    {
        gameAmbient.SetActive(false);
    }
}

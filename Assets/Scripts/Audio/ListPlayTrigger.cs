using UnityEngine;

public class ListPlayTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource trigSource;
    [SerializeField] private AudioSource shootSource;
    [SerializeField] private AudioClip[] soundList;
    [SerializeField] private AudioClip[] footStepsSoundList;
   [SerializeField]  private AudioBridge audioBridge;

    public void LoseAmbientStart()
    {
        audioBridge.LoseAmbientStartOn();
    }

    public void GameOverSound()
    {
        audioBridge = FindFirstObjectByType<AudioBridge>();
        audioBridge.GameAmbientSoundOff();
    }

    public void AmmoTake()
    {
        float p1 = 0.85f;
        float p2 = 1.2f;
        shootSource.pitch = Random.Range(p1, p2);
        shootSource.PlayOneShot(soundList[10]);
    }

    public void Hitted()
    {
        trigSource.PlayOneShot(soundList[9]);
    }

    public void Moan()
    {
        int randomMoan = Random.Range(7, 9);
        trigSource.PlayOneShot(soundList[randomMoan]);
    }

    public void Bleed()
    {
        trigSource.PlayOneShot(soundList[6]);
    }

    public void HeadShot()
    {
        trigSource.PlayOneShot(soundList[5]);
    }

    public void CorpFall()
    {
        trigSource.PlayOneShot(soundList[4]);
    }

    public void BulletWhiz()
    {
        trigSource.PlayOneShot(soundList[3]);
    }

    public void LandSound()
    {
        trigSource.PlayOneShot(soundList[2]);
    }

    public void JumpSound()
    {
        trigSource.PlayOneShot(soundList[1]);
    }

    public void ShootSound()
    {
        float p1 = 0.85f;
        float p2 = 1.2f;
        shootSource.pitch = Random.Range(p1, p2);
        shootSource.PlayOneShot(soundList[0]);
    }

    public void FootStepsSound()
    {
        if (footStepsSoundList.Length == 0) return;

        var index = Random.Range(0, footStepsSoundList.Length);
        trigSource.PlayOneShot(footStepsSoundList[index]);
    }
}

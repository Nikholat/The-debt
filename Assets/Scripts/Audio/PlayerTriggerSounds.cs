using UnityEngine;

public class PlayerTriggerSounds : MonoBehaviour
{
    [SerializeField] ListPlayTrigger listPlayTrigger;

    void Awake()
    {
        listPlayTrigger = FindFirstObjectByType<ListPlayTrigger>();
    }

    public void PlayGameOverSound()
    {
        listPlayTrigger.GameOverSound();
        listPlayTrigger.Invoke("LoseAmbientStart", 4f);
    }

    public void AmmoTakeOn()
    {
        listPlayTrigger.AmmoTake();
    }

    public void HittedOn()
    {
        listPlayTrigger.Hitted();
    }

    public void MoanOn()
    {
        listPlayTrigger.Moan();
    }

    public void BleedOn()
    {
        listPlayTrigger.Bleed();
    }

    public void HeadShotOn()
    {
        listPlayTrigger.HeadShot();
    }

    public void CorpFallOn()
    {
        listPlayTrigger.CorpFall();
    }

    public void BulletWhizSound()
    {
        listPlayTrigger.BulletWhiz();
    }

    public void LandSoundOn()
    {
        listPlayTrigger.LandSound();
    }

    public void JumpSoundOn()
    {
        listPlayTrigger.JumpSound();
    }

    public void WalkSoundSpawner()
    {
        listPlayTrigger.FootStepsSound();
    }

    public void ShootSound()
    {
        listPlayTrigger.ShootSound();
    }
}

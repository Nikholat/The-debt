using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] Animator animator;
    LoseController loseController;

    void Start()
    {
        loseController = GetComponent<LoseController>();
    }

    public void Death()
    {
        loseController.DeathControl();
        CrouchOff();
        JumpingOff();
        animator.SetTrigger("Death");
    }

    public void Jumping(bool isGrounded)
    {
        animator.SetBool("isJumping", !isGrounded);
    }

    public void JumpingOff()
    {
        animator.SetBool("isJumping", false);
    }

    public void VeloctyCheck(Rigidbody2D rb)
    {
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    public void Crouch()
    {
        animator.SetBool("isCrouch", true);
    }

    public void CrouchOff()
    {
        animator.SetBool("isCrouch", false);
    }
}

using UnityEngine;
using System.Collections;
using Unity.Mathematics;


public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] AnimatorController anim;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform arms;
    [SerializeField] Transform head;
    private PlayerTriggerSounds playerTriggerSounds;
    private CapsuleCollider2D playerCollider;

    [Header("Parameters")]

    [SerializeField] private float acceleration;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _distanceFromGround;
    private Vector2 desiredVelocity;
    private float xInputSave;
    private bool shiftIsPressed;
    private bool SIsPressed;
    private bool isGrounded = true;


    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
        playerTriggerSounds = GetComponent<PlayerTriggerSounds>();
    }

    void Update()
    {
        xInputSave = Input.GetAxis("Horizontal");

        shiftIsPressed = Input.GetKey(KeyCode.LeftShift);

        SIsPressed = Input.GetKey(KeyCode.S);

        PlayerSit();

        Jumping();

        SpriteFlip(xInputSave);
    }

    void FixedUpdate()
    {
        anim.VeloctyCheck(rb);
        if (!SIsPressed)
            WalkAndRun(xInputSave);
    }

    private void PlayerSit()
    {
        if (SIsPressed && isGrounded)
        {
            arms.transform.localPosition = new Vector2(0.057f, -0.41f);

            head.transform.localPosition = new Vector2(0.189f, -0.07f); //-0.041f

            playerCollider.size = new Vector2(0.75f, 0.75f);

            playerCollider.offset = new Vector2(-0.006623864f, -0.5366564f);

            anim.Crouch();

            spriteRenderer.flipX = false;

            SIsPressed = true;

            rb.linearVelocityX = 0;
        }
        else
        {
            arms.transform.localPosition = new Vector2(0.026f, 0.023f);

            head.transform.localPosition = new Vector2(-0.026f, 0.377f);

            playerCollider.size = new Vector2(0.75f, 1.816917f);

            playerCollider.offset = new Vector2(-0.006623864f, -0.08742809f);

            anim.CrouchOff();

            SIsPressed = false;
        }
    }

    private void SpriteFlip(float xInput)
    {
        if (!SIsPressed)
            spriteRenderer.flipX = xInput < 0;
    }

    private void WalkAndRun(float xInput)
    {
        if (Mathf.Abs(xInput) > 0.01f)
        {
            if (shiftIsPressed)
            {
                desiredVelocity = new Vector2(xInput * runSpeed, rb.linearVelocity.y);
            }
            else
            {
                desiredVelocity = new Vector2(xInput * walkSpeed, rb.linearVelocity.y);
            }

            var maxSpeedChange = acceleration * Time.fixedDeltaTime;

            var velocity = rb.linearVelocity;

            velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

            rb.linearVelocity = velocity;
        }
    }

    private void Jumping()
    {
        bool wasGrounded = isGrounded;
        LayerMask _groundLayer = LayerMask.GetMask("Ground");
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _distanceFromGround, _groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerTriggerSounds.JumpSoundOn();
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            anim.Jumping(isGrounded);
        }
        if (!wasGrounded && isGrounded)
        {
            isGrounded = true;
            playerTriggerSounds.LandSoundOn();
        }
        anim.Jumping(isGrounded);
        Debug.DrawRay(transform.position, Vector2.down * _distanceFromGround, Color.red, 1000);
    }
}

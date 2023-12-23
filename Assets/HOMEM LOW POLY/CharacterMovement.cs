using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpspeed = 15.0f;
    public float standing = -1.5f;
    public float gravity = -9.8f;
    public float ySpeed = -1.5f;
    public float minSpeed = -10.0f;
    public CharacterController characterController;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX,0,moveZ);
        movement = Vector3.ClampMagnitude(movement,1.0f);
        float velocity = movement.magnitude;
        if (movement != Vector3.zero &&
         ( Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ))
        {
            velocity *= 2;
        }
        animator.SetFloat("Speed",velocity);
        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("jump"))
            {
                ySpeed = jumpspeed;
                animator.SetBool("jumping",true);
            }
            else
            {
                ySpeed = standing;
                animator.SetBool("jumping",false);
            }
        }
        else
        {
            ySpeed += gravity * 5 * Time.deltaTime;
            if (ySpeed < minSpeed)
            {
                ySpeed = minSpeed;
            }
        }
        movement *= moveSpeed;
        movement.y = ySpeed;
        movement *= Time.deltaTime;
        characterController.Move(movement);
    }
}

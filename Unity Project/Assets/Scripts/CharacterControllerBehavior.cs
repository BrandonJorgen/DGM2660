using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerBehavior : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 position;
    private float yRotation, extraJumpCount = 0f, gravity = 9.81f;

    public float moveSpeed, rotateSpeed, jumpSpeed, extraJumpCountMax = 1f;
    public bool tankControls, shrunk, canMove;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (canMove)
        {
            if (controller.isGrounded)
            {
                if (!tankControls)
                {
                    position.Set(moveSpeed * Input.GetAxis("Horizontal"), 0, moveSpeed * Input.GetAxis("Vertical"));
                }
                else
                {
                    yRotation += rotateSpeed * Input.GetAxis("Horizontal");
                    transform.eulerAngles = new Vector3(0, yRotation, 0);
                    position.Set(0, 0, moveSpeed * Input.GetAxis("Vertical"));
                    position = transform.TransformDirection(0, 0, moveSpeed * Input.GetAxis("Vertical"));
                }

                extraJumpCount = 0;
            }
        
            position.y -= gravity * Time.deltaTime;
            controller.Move(position * Time.deltaTime);
        }
    }

    public void ShrinkController()
    {
        if (!shrunk)
        {
            shrunk = true;
        }
        
        if (shrunk)
        {
            controller.radius = controller.radius / 2;
            controller.height = 0.5f;
        }
    }

    public void StartStopMovement()
    {
        if (canMove)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            position.y = jumpSpeed;
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (extraJumpCount < extraJumpCountMax)
                {
                    position.y = jumpSpeed;
                    extraJumpCount++;
                }
            }
        }
        controller.Move(position * Time.deltaTime);
    }

    public void CrouchDown()
    {
        if (controller.isGrounded)
        {
            controller.height = 0.5f;
        }
    }

    public void CrouchUp()
    {
        controller.height = 1;
    }

    public void SetTankControls()
    {
        if (tankControls)
        {
            tankControls = false;
        }
        else
        {
            tankControls = true;
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerBehavior : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 position;
    private float yRotation, extraJumpCount = 0f, gravity = 9.81f;

    public float moveSpeed, rotateSpeed, jumpSpeed, extraJumpCountMax = 1f;
    public bool tankControls, shrunk;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
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
            
            if (Input.GetButtonDown("Jump"))
            {
                position.y = jumpSpeed;
            }

            if (!shrunk)
            {
                if (Input.GetButton("Fire1"))
                {
                    controller.height = controller.height / 2;
                }
                else
                {
                    controller.height = 1;
                }
            }
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
        
        position.y -= gravity * Time.deltaTime;
        controller.Move(position * Time.deltaTime);
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
            controller.height = controller.height / 2;
        }
    }
}
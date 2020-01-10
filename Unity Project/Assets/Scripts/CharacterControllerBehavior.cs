using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerBehavior : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 position;

    public float moveSpeed, rotateSpeed, yRotation, jumpSpeed, extraJumpCount = 0f, extraJumpCountMax =1f, gravity = 9.81f;
    public bool tankControls;
    
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
}
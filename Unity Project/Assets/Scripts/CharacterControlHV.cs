using UnityEngine;

[CreateAssetMenu]
public class CharacterControlHV : ScriptableObject
{
    private Vector3 position;

    public float moveSpeed = 5f, jumpSpeed = 10f, gravity = 9.81f;
    
    public void MoveCharacter(CharacterController controller)
    {
        if (controller.isGrounded)
        {
            position.Set(Input.GetAxis("Horizontal") * moveSpeed, 0, Input.GetAxis("Vertical") * moveSpeed);
        }

        position.y -= gravity * Time.deltaTime;
        controller.Move(position * Time.deltaTime);
    }

    public void Jump(CharacterController controller)
    {
        if (controller.isGrounded)
        {
            position.y = jumpSpeed;
        }
        
        controller.Move(position * Time.deltaTime);
    }

    public void CrouchDown(CharacterController controller)
    {
        if (controller.isGrounded)
        {
            controller.height = 0.5f;
        }
    }
    
    public void CrouchUp(CharacterController controller)
    {
        controller.height = 1;
    }
}
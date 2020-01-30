using UnityEngine;

[CreateAssetMenu]
public class CharacterControlTank : ScriptableObject
{
    private Vector3 position, rotation;

    public float moveSpeed = 5f, rotationSpeed = 0.75f, jumpSpeed = 10f, gravity = 9.81f;

    public void MoveCharacter(CharacterController controller)
    {
        if (controller.isGrounded)
        {
            position.Set(0, 0, Input.GetAxis("Vertical") * moveSpeed);
            rotation.y = rotationSpeed * Input.GetAxis("Horizontal");
            controller.transform.Rotate(rotation);
        }
        
        position = controller.transform.TransformDirection(position);
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
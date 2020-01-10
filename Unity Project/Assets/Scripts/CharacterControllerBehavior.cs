using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerBehavior : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 position;

    public float moveSpeed, rotateSpeed, gravity = 9.81f;
    public bool tankControls;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        position.y -= gravity;

        if (!tankControls)
        {
            position.x = moveSpeed * Input.GetAxis("Horizontal");
            position.z = moveSpeed * Input.GetAxis("Vertical");
        }
        else
        {
            transform.Rotate(0, rotateSpeed * Input.GetAxis("Horizontal"), 0);
        }
        
        controller.Move(position * Time.deltaTime);
    }
}
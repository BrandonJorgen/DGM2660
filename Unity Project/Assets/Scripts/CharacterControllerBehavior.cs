using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerBehavior : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 position;

    public float moveSpeed, gravity = -9.81f;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        position.x = moveSpeed * Input.GetAxis("Horizontal");
        position.z = moveSpeed * Input.GetAxis("Vertical");
        
        controller.Move(position * Time.deltaTime);
    }
}

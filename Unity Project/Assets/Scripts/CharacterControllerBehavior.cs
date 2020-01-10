using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerBehavior : MonoBehaviour
{
    private CharacterController controller;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
}

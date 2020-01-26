using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimTriggerBehavior : MonoBehaviour
{
    private Animator animator;

    public UnityEvent wKeyEvent, sKeyEvent, aKeyEvent, dKeyEvent, noKeyEvent;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.inputString == "")
        {
            noKeyEvent.Invoke();
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                wKeyEvent.Invoke();
            }
    
            if (Input.GetKey(KeyCode.S))
            {
                sKeyEvent.Invoke();
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                aKeyEvent.Invoke();
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                dKeyEvent.Invoke();
            }
        }
    }
}
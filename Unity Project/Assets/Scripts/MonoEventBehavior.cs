using UnityEngine;
using UnityEngine.Events;

public class MonoEventBehavior : MonoBehaviour
{
    public UnityEvent onStartEvent, onUpdateEvent;

    private void Start()
    {
        onStartEvent.Invoke();
    }

    private void Update()
    {
        onUpdateEvent.Invoke();
    }
}
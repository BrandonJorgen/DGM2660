using UnityEngine;

[CreateAssetMenu]
public class Debugger : ScriptableObject
{
    public void EventDebug()
    {
        Debug.Log(this + " Event has been called");
    }
}
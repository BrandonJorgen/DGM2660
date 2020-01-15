using UnityEngine;

public class IDMatch : MonoBehaviour
{
    public IDName nameIDObj;
    
    private void OnTriggerEnter(Collider other)
    {
        var nameIdObj = other.GetComponent<IDName>().nameIDObj;
        if (nameIdObj == null) return;
        var otherNameId = nameIdObj;
        if (nameIDObj == otherNameId)
        {
            //do work
        }
    }
}

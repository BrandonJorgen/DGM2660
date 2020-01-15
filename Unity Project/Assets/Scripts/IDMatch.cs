using System.Collections.Generic;
using UnityEngine;

public class IDMatch : MonoBehaviour
{
    public List<IDName> IDNameObj;
    
    private void OnTriggerEnter(Collider other)
    {
        var nameIdObj = other.GetComponent<IDBehavior>().IDNameObj;
        if (nameIdObj == null) return;
        var otherNameId = nameIdObj;

        foreach (var ID in IDNameObj)
        {
            if (ID == otherNameId)
            {
                Debug.Log(otherNameId + " Matches: " + ID + " and is attached to: " + other);
                return;
            }
        }
    }
}
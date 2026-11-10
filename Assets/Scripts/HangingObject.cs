
using UnityEngine;
using System.Collections.Generic;

public class HangingObject : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField]List<GameObject> lockObjects = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateStatus(GameObject objToRemove)
    {
       
            if (lockObjects.Contains(objToRemove))
                lockObjects.Remove(objToRemove);
        
        if(lockObjects.Count <= 0)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}

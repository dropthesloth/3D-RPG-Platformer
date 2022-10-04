using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckTarget : MonoBehaviour
{
    public Transform target;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<EnemyStats>().Aim += Aim;
        radius = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Aim()
    {
        
        float distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
        Debug.Log("ready to aim");
        if (distance <= radius)
        {
            Quaternion faceDirection = Quaternion.LookRotation(target.position - gameObject.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, faceDirection, Time.deltaTime * 1);
            Debug.Log("aiming!");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    }
}

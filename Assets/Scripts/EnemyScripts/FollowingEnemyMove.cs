using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowingEnemyMove : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = this.gameObject.GetComponent<NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void Aim()
    {
        
    }
    public void Follow(Transform player)
    {
        
            enemyAgent.SetDestination(player.transform.position);
            // rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.y * speed);
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), radius);     
    }
}

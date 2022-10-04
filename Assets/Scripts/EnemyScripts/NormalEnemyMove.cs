using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalEnemyMove : MonoBehaviour
{
    IEnemy enemyInterfaceRef;
    public float turnTimer;
    bool movingRight;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        turnTimer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnTimer >= 5)
        {
            moveDirection = new Vector2(0, 1);
            gameObject.GetComponent<EnemyStats>().moveDirection = moveDirection;
            movingRight = true;      
            Debug.Log("go right");
        }
        else if (turnTimer <= 0)
        {
            moveDirection = new Vector2(0, -1);
            gameObject.GetComponent<EnemyStats>().moveDirection = moveDirection;
            movingRight = false;
        }

        if (movingRight)
        {
            turnTimer -= Time.deltaTime;
        }
        if (!movingRight)
        {
            turnTimer += Time.deltaTime;
        }
       
    }
}

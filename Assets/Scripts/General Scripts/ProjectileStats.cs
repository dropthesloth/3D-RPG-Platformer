using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStats : MonoBehaviour
{ 
    public Projectile projectileObject;
    float chargeTime;
    float destroyTimer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        chargeTime = projectileObject.chargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileObject.hasChargeTime)
        { 
             if (chargeTime > 0)
             { 
                 chargeTime -= Time.deltaTime;
                 //gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                 gameObject.transform.localScale += new Vector3(Time.deltaTime * (chargeTime), Time.deltaTime * (chargeTime), Time.deltaTime * (chargeTime));
             }
        }
        if (projectileObject.hasChargeTime == false || projectileObject.hasChargeTime && chargeTime <= 0)
        gameObject.transform.position += transform.forward * projectileObject.speed;
    
        destroyTimer -= Time.deltaTime;
        if(destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != gameObject.tag)
        {
            if (other.gameObject.tag == "Player")
                other.gameObject.GetComponent<Stats>().TakeDamage(projectileObject.damage);  
           
            else if(other.gameObject.tag == "Enemy")
            {
                if (other.gameObject.GetComponent<EnemyStats>().Weakness == projectileObject)
                    other.gameObject.GetComponent<Stats>().TakeDamage(projectileObject.damage * 2);
                else if(other.gameObject.GetComponent<EnemyStats>().Resistance == projectileObject)
                { 
                other.gameObject.GetComponent<Stats>().TakeDamage(projectileObject.damage / 2);
                    Debug.Log("take resisted damage");
                }
                else
                {
                    other.gameObject.GetComponent<Stats>().TakeDamage(projectileObject.damage); 
                }
            }
                Destroy(gameObject);            
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePowerUp : MonoBehaviour
{
    public Projectile projectile;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().projectileShootRef == null)
            {
                other.GetComponent<PlayerController>().projectileShootRef = other.gameObject.AddComponent<ProjectileShoot>();
                //other.GetComponent<PlayerController>().playerInputInterface.SwitchProjectileInput += other.GetComponent<PlayerController>().projectileShootRef.SwitchProjectile;
            }
            
            other.GetComponent<PlayerController>().projectileShootRef.projectileObject = projectile;
            other.GetComponent<PlayerController>().projectileShootRef.projectiles.Add(projectile);            
            //other.GetComponent<PlayerController>().playerInputInterface.ShootInput += other.GetComponent<PlayerController>().projectileShootRef.Shoot;
            
            gameObject.SetActive(false);
            //Give player fireball
        }

    }
}

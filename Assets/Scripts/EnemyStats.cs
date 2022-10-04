using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IEnemy
{
    [SerializeField] ProjectileShoot projectileShootRef;
    public event EnemyActions Shoot = delegate { };
    public event EnemyMovePattern Move = delegate { };
    //public event EnemyFollowTarget FollowPlayer = delegate { };
    public event EnemyActions Aim = delegate { };

    [SerializeField]Projectile weakness;
    public Projectile Weakness { get {return weakness; } }
    [SerializeField] Projectile resistance;
    public Projectile Resistance { get { return resistance; } }
    public GameObject player;
    float shootTimer;
    public Vector3 moveDirection;
    Stats statsRef;
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        shootTimer = 5f;
        statsRef = gameObject.GetComponent<Stats>();
        statsRef.maxHealth = maxHealth;
        player = GameObject.Find("Player");
        Shoot += gameObject.GetComponent<ProjectileShoot>().Shoot;
        Move += gameObject.GetComponent<Movement>().Move;
        //FollowPlayer += gameObject.GetComponent<FollowingEnemyMove>().Follow;

    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectile();
        MoveEnemy();
        if(Aim != null)
        AimAt();
        if(statsRef.currentHealth <= 0)
        {
            Debug.Log("why are you dead");
            Destroy(this.gameObject);
        }
        //Follow();
    }
    public void AimAt()
    {
        if(Aim != null)       
        Aim();        
    }
    void ShootProjectile()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Shoot != null)
        {
            Shoot();
        }
    }
    void MoveEnemy()
    {
        if (Move != null)
            Move(moveDirection);
    }  
    /*void Follow()
    {
        if(FollowPlayer != null)
        {
        float radius = 5;
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance <= radius)
        {
                FollowPlayer(player.transform);
        }
            Gizmos.DrawWireSphere(gameObject.transform.position, radius);
        }
       
    }*/
}

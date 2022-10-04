using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProjectileShoot : MonoBehaviour
{
    [HideInInspector] public bool shootProjectile;
    public float shootCoolDown;
    [HideInInspector] public bool isSpreadShot;
    public GameObject spawnPosition;
    public List<Projectile> projectiles = new List<Projectile>();
    public Projectile projectileObject;
    public Image currentProjectileImage;
    // Start is called before the first frame update
    void Start()
    {
        currentProjectileImage = GameObject.Find("CurrentProjectile").GetComponent<Image>();
        //currentProjectileImage.color = projectileObject.projectile.GetComponent<Material>().color;
        if (spawnPosition == null)
            spawnPosition = GameObject.Find("ProjectilePoint");
        shootCoolDown = 0;
        shootProjectile = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCoolDown > 0)
        {
            shootProjectile = false;
            shootCoolDown -= Time.deltaTime;
        }
        else if (shootCoolDown <= 0 && !shootProjectile)
        {
            shootProjectile = true;
        }
    }
    public void Shoot()
    {

        if (shootProjectile)
        {
            Debug.Log("Shot projectile");
            //shoot projectile
            Instantiate(projectileObject.projectile, spawnPosition.transform.position, Quaternion.LookRotation(transform.forward));
            shootCoolDown = projectileObject.shootCoolDown;
            if (projectileObject.isSpreadShot)
            {
                Instantiate(projectileObject.projectile, spawnPosition.transform.position, transform.rotation * Quaternion.Euler(0f, 30f, 0f));
                Instantiate(projectileObject.projectile, spawnPosition.transform.position, transform.rotation * Quaternion.Euler(0f, -30f, 0f));
            }
        }
    }
    public static int ClampListIndex(int pIndex, int pListSize) => ((pIndex % pListSize) + pListSize) % pListSize;
    public void SwitchProjectile(bool nextProjectile)
    {
        int i = projectiles.IndexOf(projectileObject);
        int change = nextProjectile ? -1 : 1;
        //i = (int)Mathf.Repeat(i + change, projectiles.Count - 1);
        //i = (((i + change) + projectiles.Count) % projectiles.Count);
        i = ClampListIndex(i + change, projectiles.Count);
        print(i);
        projectileObject = projectiles[i];
        //currentProjectileImage.color = projectileObject.projectile.GetComponent<Material>().color;
        return;
    }
}

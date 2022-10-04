using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentElement : MonoBehaviour
{
    public List<Projectile> projectiles = new List<Projectile>();
    public ProjectileShoot projectileShootRef;
    public Image currentProjectileImage;
    // Start is called before the first frame update
    void Start()
    {
        currentProjectileImage = GameObject.Find("CurrentProjectile").GetComponent<Image>();
        projectileShootRef = gameObject.GetComponent<ProjectileShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentProjectileImage.color != projectileShootRef.gameObject.GetComponent<Material>().color)
        currentProjectileImage.color = projectileShootRef.gameObject.GetComponent<Material>().color;
    }
    public void SwitchProjectile(bool nextProjectile)
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            print(projectiles.Count.ToString());
            if (projectileShootRef.projectileObject = projectiles[i])
            {
                Debug.Log("Amount of projectiles = " + projectiles.Count.ToString());
                if (nextProjectile && (i + 1) <= projectiles.Count)
                {
                    Debug.Log(projectiles[i + 1].name);
                    projectileShootRef.projectileObject = projectiles[i + 1];
                    print("Next element");
                    return;
                }
                else if (!nextProjectile && (i - 1) >= projectiles.Count)
                {
                    Debug.Log(projectiles[i - 1].name);
                    projectileShootRef.projectileObject = projectiles[i - 1];
                    print("Previous Element");
                    return;
                }
            }
        }
    }
}

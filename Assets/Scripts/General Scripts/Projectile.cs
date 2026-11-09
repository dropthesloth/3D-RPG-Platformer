using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Objects/Projectile")]
public class Projectile : ScriptableObject
{
    public int damage;
    public bool isSpreadShot;
    public bool hasChargeTime;
    public float chargeTime;
    public float speed;
    public float shootCoolDown;
    public GameObject projectile;
    public Color projectileColor;
}

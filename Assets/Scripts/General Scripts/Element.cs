using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Objects/Element")]
public class Element : ScriptableObject
{
    public int projectileDamage;
    public int meleeDamage;
    public float projectileSpeed;
}

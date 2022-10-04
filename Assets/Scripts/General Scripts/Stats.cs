using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour, IHealth
{
    public int maxHealth;
    public int currentHealth;
    public int attack;
    public int MaxHealth { get { return maxHealth; } }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void TakeDamage(int pDamage)
    {
        currentHealth -= pDamage;
    }

}

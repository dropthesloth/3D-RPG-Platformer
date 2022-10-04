using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBar : MonoBehaviour
{
    public Stats statsRef;
    Image healthBar;
    float health;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = this.gameObject.GetComponent<Image>();
        health = statsRef.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > statsRef.currentHealth) 
        { 
            health -= Time.deltaTime * (health + statsRef.currentHealth);
            healthBar.fillAmount = health / statsRef.MaxHealth;
        }
        if(health <= 0.1)
        {
            Debug.Log("what");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}

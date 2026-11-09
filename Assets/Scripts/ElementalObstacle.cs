using UnityEngine;

public class ElementalObstacle : MonoBehaviour
{
    [SerializeField] Projectile weakness;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fire"))
        {
            this.gameObject.SetActive(false);
        }
    }
}

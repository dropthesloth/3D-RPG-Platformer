using UnityEngine;
using UnityEngine.Events;

public class ElementalObstacle : MonoBehaviour
{
    [SerializeField] Projectile weakness;
    public UnityEvent destroyEvent;
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
            if (destroyEvent != null)
                destroyEvent.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}

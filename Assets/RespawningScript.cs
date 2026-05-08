using UnityEngine;

public class RespawningScript : MonoBehaviour
{
    GameObject currentRespawnPoint;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        currentRespawnPoint = new GameObject();
        currentRespawnPoint.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            currentRespawnPoint = other.gameObject;
        }
        if (other.CompareTag("DeathZone"))
        {
            rb.linearVelocity = Vector3.zero;
            this.gameObject.transform.position = currentRespawnPoint.transform.position;
        }
    }
}

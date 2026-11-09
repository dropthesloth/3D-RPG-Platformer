using UnityEngine;

public class BrittlePlatform : MonoBehaviour
{
    [SerializeField] float breakTimer;
    bool steppedOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        steppedOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (breakTimer <= 0)
            this.gameObject.SetActive(false);
        if (steppedOn)
            breakTimer -= Time.deltaTime;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
            steppedOn = true;
    }
}

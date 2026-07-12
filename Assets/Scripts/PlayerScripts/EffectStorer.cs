using UnityEngine;

public class EffectStorer : MonoBehaviour
{
    public ParticleSystem windEffect;
    //public GameObject fireEffect;
    public static EffectStorer instance;
    private void Awake()
    {
        instance = this;
        windEffect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField] Movement moveRef;
    //[SerializeField] PlayerJump jumpRef;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetBool("IsRunning", moveRef.isMoving);
    }
}

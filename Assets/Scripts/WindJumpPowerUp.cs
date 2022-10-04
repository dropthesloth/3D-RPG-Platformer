using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindJumpPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Adds double jump/wind jump component to the player
            other.GetComponent<PlayerController>().windJumpRef = other.gameObject.AddComponent<WindJump>();
            other.GetComponent<PlayerController>().playerInputInterface.WindJumpInput += other.GetComponent<PlayerController>().windJumpRef.DoubleJump;
            gameObject.SetActive(false);
        }
    }
}

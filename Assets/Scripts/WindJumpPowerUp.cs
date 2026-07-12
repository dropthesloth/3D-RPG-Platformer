using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpPowerUp
{
    void AddComponentToPlayer(GameObject pPlayer);
}

public class WindJumpPowerUp : MonoBehaviour, IJumpPowerUp
{
    public void AddComponentToPlayer(GameObject pPlayer)
    {
        //adds wind jump component to the player
        pPlayer.GetComponent<PlayerController>().windJumpRef = pPlayer.gameObject.AddComponent<WindJump>();
        pPlayer.GetComponent<PlayerController>().playerInputInterface.WindJumpInput += pPlayer.GetComponent<PlayerController>().windJumpRef.DoubleJump;
        gameObject.SetActive(false);
    }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashPowerUp
{
    void AddComponentToPlayer(GameObject pPlayer);
}


public class FlameDashPowerUp : MonoBehaviour, IDashPowerUp
{
    public void AddComponentToPlayer(GameObject pPlayer)
    {
        //adds flame dash component to the player
        pPlayer.GetComponent<PlayerController>().flameDashRef = pPlayer.gameObject.AddComponent<FlameDash>();
        //pPlayer.GetComponent<PlayerController>().playerInputInterface.FlameDashInput += pPlayer.GetComponent<PlayerController>().flameDashRef.Dash;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {      
        if (other.CompareTag("Player"))
        {
            AddComponentToPlayer(other.gameObject);
        }
    }
}

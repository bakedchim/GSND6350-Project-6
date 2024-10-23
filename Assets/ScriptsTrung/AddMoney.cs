using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{

    public PlayerInfo playerInfo;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInfo.gold += 200;
            Destroy(gameObject);
        }
    }
}

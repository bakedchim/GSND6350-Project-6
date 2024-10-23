using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NearBoat : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public TMP_Text nearBoatText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.isNearBoat = true;
            nearBoatText.gameObject.SetActive(true);
            nearBoatText.text = "Press E to board";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.isNearBoat = false;
            nearBoatText.gameObject.SetActive(false);
        }
    }
}

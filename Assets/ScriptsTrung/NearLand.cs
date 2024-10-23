using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NearLand : MonoBehaviour
{
    public TMP_Text prompt;
    public PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerMovement.isOnBoat)
        {
            playerMovement.isNearLand = true;
            prompt.gameObject.SetActive(true);
            prompt.text = "Press E to disembark";
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player") && playerMovement.isOnBoat)
        {
            playerMovement.isNearLand = true;
            prompt.gameObject.SetActive(true);
            prompt.text = "Press E to disembark";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.isNearLand = false;

            if (playerMovement.isOnBoat)
            {
                prompt.gameObject.SetActive(false);
            }
        }
    }
}

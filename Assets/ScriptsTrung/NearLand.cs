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
            prompt.gameObject.SetActive(true);
            prompt.text = "Press E to disembark";
        }
    }
}

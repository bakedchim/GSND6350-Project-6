using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NearBoat : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public TMP_Text nearBoatText;

    bool isDecreasing = false;

    IEnumerator currentCoroutine;

    private void Start()
    {
        currentCoroutine = ReduceDurability();
    }

    private void Update()
    {
        if (playerMovement.isOnBoat && !isDecreasing)
        {
            StartCoroutine(currentCoroutine);
            isDecreasing = true;
        } else if (!playerMovement.isOnBoat)
        {
            StopCoroutine(currentCoroutine);
            isDecreasing = false;
        }
    }

    IEnumerator ReduceDurability()
    {
        while(true) {
            yield return new WaitForSeconds(1.2f);
            playerMovement.playerInfo.boatDurability -= 2;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerMovement.isOnBoat)
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

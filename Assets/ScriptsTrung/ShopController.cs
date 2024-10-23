using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public int repairCost = 0;
    public int upgradeCost = 0;
    public int numberOfTimesUpgraded = 0;
    public PlayerInfo playerInfo;
    public bool isNearShop = false;
    public TMP_Text costText;
    string repairText;
    string upgradeText;
    private void Update()
    {
        if (numberOfTimesUpgraded == 0)
        {
            upgradeCost = 100;
        }
        else if (numberOfTimesUpgraded == 1)
        {
            upgradeCost = 200;
        }
        repairCost = 5 * (playerInfo.boatMaxDurability - playerInfo.boatDurability);
        if (playerInfo.boatDurability < playerInfo.boatMaxDurability) {
            repairText = "Press R to repair for " + repairCost + " gold";
        }
        else
        {
            repairText = "Boat is at full health";
        }
        if (numberOfTimesUpgraded < 2)
        {
            upgradeText = "Press U to upgrade for " + upgradeCost + " gold";
        }
        else
        {
            upgradeText = "Boat is at max level";
        }

        if (isNearShop && Input.GetKeyDown(KeyCode.R))
        {
            Repair();
        }
        if (isNearShop && Input.GetKeyDown(KeyCode.U))
        {
            Upgrade();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearShop = true;
            costText.gameObject.SetActive(true);
            costText.text = repairText + "\n" + upgradeText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearShop = false;
            costText.gameObject.SetActive(false);
        }
    }

    public void Repair()
    {
        if (playerInfo.gold >= repairCost)
        {
            playerInfo.gold -= repairCost;
            playerInfo.boatDurability = playerInfo.boatMaxDurability;
        }
    }

    public void Upgrade()
    {
        if (playerInfo.gold >= upgradeCost && numberOfTimesUpgraded < 2)
        {
            playerInfo.gold -= upgradeCost;
            playerInfo.boatSpeed += 8;
            playerInfo.boatMaxDurability += 50;
            playerInfo.treasureCapacity += 1;
            numberOfTimesUpgraded++;
        }
    }
}

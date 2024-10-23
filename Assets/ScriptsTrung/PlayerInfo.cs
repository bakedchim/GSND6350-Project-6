using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameControllerTrung gameControllerTrung;
    public int boatDurability = 100;
    public int boatSpeed = 10;
    public int treasureCapacity = 2;
    public int treasure = 0;
    public int gold = 0;
    
    public TMP_Text goldText;
    public TMP_Text treasureText;
    public TMP_Text boatDurabilityText;

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + gold;
        treasureText.text = "Treasure: " + treasure + "/" + treasureCapacity;
        boatDurabilityText.text = "Boat Durability: " + boatDurability;
        
        if (boatDurability <= 0)
        {
            gameControllerTrung.LoseGame();
        }
    }
}

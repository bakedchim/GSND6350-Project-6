using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogAdvance : MonoBehaviour
{
    public GameControllerTrung gameControllerTrung;
    public string[] dialogs;
    public int index = 0;
    public TMP_Text text;
    public TMP_Text buttonText;
    public GameObject panel;

    // Update is called once per frame
    void Update()
    {
        text.text = dialogs[index];
    }

    public void Next()
    {
        index++;
        if (index == dialogs.Length -1)
        {
            buttonText.text = "Close";
        }
        if (index >= dialogs.Length)
        {
            index = 0;
            panel.SetActive(false);
            gameControllerTrung.gameStarted = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

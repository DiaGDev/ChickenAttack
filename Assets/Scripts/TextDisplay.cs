using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public PlayerController playerController;
    private TextMeshProUGUI uiText;

    void Start()
    {
        // Get a reference to the TextMeshProUGUI component on this object
        uiText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Get the remaining cooldown time from the PlayerController
        float remainingCooldown = playerController.dashCoolCounter;

        // Display the remaining cooldown time in the TextMeshProUGUI element
        uiText.text = "DashCD: " + remainingCooldown.ToString("0.00");
    }
}
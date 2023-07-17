using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VigorPotionsCounter : MonoBehaviour
{
    private TextMeshProUGUI VigotPotionsCounter;
    public inventoryObjectsActions inventoryObjectsActionsScript;

    private void Start()
    {
        VigotPotionsCounter = GetComponent<TextMeshProUGUI>();

    }
    public void Update()
    {

        VigotPotionsCounter.text = inventoryObjectsActionsScript.VigorPotions.ToString();

    }
}

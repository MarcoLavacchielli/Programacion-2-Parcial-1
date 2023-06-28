using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPotionsCounter : MonoBehaviour
{
    private TextMeshProUGUI HealthPotsCounter;
    public inventoryObjectsActions inventoryObjectsActionsScript;

    private void Start()
    {
        HealthPotsCounter = GetComponent<TextMeshProUGUI>();

    }
    public void Update()
    {
       
        HealthPotsCounter.text = inventoryObjectsActionsScript.HealthPotions.ToString();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AguilePotionsCounter : MonoBehaviour
{
    private TextMeshProUGUI AguilePotionsCounts;
    public inventoryObjectsActions inventoryObjectsActionsScript;

    private void Start()
    {
        AguilePotionsCounts = GetComponent<TextMeshProUGUI>();

    }
    public void Update()
    {

        AguilePotionsCounts.text = inventoryObjectsActionsScript.AguilePotions.ToString();

    }
}

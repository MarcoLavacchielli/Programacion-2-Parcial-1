using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaludContador : MonoBehaviour
{
    public StadisticPlayer stadisticPlayerScript;
    private TextMeshProUGUI ContadorSalud;

    private void Start()
    {
        ContadorSalud = GetComponent<TextMeshProUGUI>();
        
    }
    public void Update()
    {
        ContadorSalud.text = stadisticPlayerScript.health.ToString();
      
    }

}

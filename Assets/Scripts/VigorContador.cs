using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VigorContador : MonoBehaviour
{
    public StadisticPlayer stadisticPlayerScript;
    private TextMeshProUGUI ContadorVigor;

    private void Start()
    {
        ContadorVigor = GetComponent<TextMeshProUGUI>();

    }
    public void Update()
    {
        ContadorVigor.text = stadisticPlayerScript.vigor.ToString();

    }
}

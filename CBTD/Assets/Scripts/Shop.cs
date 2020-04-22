using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public float potato = 0f;
    public TextMeshProUGUI potatotext = null;

    void Start()
    {
        
    }

    void Update()
    {
        potatotext.text = potato.ToString();
    }
}

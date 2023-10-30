using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageTextController : MonoBehaviour
{
    public TMP_Text messageTextComponent;
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance.IsWin == true)
            messageTextComponent.text = "Brawo! Wygrałeś";
        else
            messageTextComponent.text = "Niestety przegrałeś";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Controls the display of a win/loss message in the game using TextMeshPro.
/// </summary>
public class MessageTextController : MonoBehaviour
{
    /// <summary>
    /// The TextMeshPro component used to display the message.
    /// </summary>
    public TMP_Text messageTextComponent;

    /// <summary>
    /// Called when the script is initialized.
    /// Sets the message text based on the game outcome.
    /// </summary>
    void Start()
    {
        if (DataManager.Instance.IsWin == true)
            messageTextComponent.text = "Brawo! Wygrałeś";
        else
            messageTextComponent.text = "Niestety przegrałeś";
    }
}

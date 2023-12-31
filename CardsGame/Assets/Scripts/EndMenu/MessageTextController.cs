﻿using TMPro;
using UnityEngine;

namespace EndMenu
{
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
        private void Start()
        {

            messageTextComponent.text = $"Koniec gry! Twoje punkty: {DataManager.Instance.points}";

        }
    }
}
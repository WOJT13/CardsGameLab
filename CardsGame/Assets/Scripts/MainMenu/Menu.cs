using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    /// <summary>
    /// Controls the main menu and user interactions for starting the game.
    /// </summary>
    public class Menu : MonoBehaviour
    {
        /// <summary>
        /// The TextMeshPro input field for entering a player's nickname.
        /// </summary>
        public TMP_InputField nickInputField;

        /// <summary>
        /// Called when the "Start" button is clicked.
        /// Sets the player's nickname and starts the game if required data is provided.
        /// </summary>
        public void OnStartButtonClick()
        {
            DataManager.Instance.nickName = nickInputField.text;

            if (!string.IsNullOrWhiteSpace(DataManager.Instance.nickName) && !string.IsNullOrWhiteSpace(DataManager.Instance.difficultyLevel.name))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
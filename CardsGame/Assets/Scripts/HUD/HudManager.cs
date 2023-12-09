using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    /// <summary>
    /// Manages the Head-Up Display (HUD) element
    /// </summary>
    public class HudManager : MonoBehaviour
    {
        /// <summary>
        /// Reference to the Text Mesh Pro (TMP) text component for the player's nickname.
        /// </summary>
        public TMP_Text nicknameText;

        /// <summary>
        /// Reference to the Text Mesh Pro (TMP) text component for the points.
        /// </summary>
        public TMP_Text pointsText;

        /// <summary>
        /// Reference to the Text Mesh Pro (TMP) text component for the cards left in hand.
        /// </summary>
        public TMP_Text cardsText;

        /// <summary>
        /// Reference to the Text Mesh Pro (TMP) text component for the cards left in deck.
        /// </summary>
        public TMP_Text cardsInDeckText;

        /// <summary>
        /// Reference to the Text Mesh Pro (TMP) text component for bombs count.
        /// </summary>
        public TMP_Text bombsCount;

        /// <summary>
        /// Reference to the Text Mesh Pro (TMP) text component for doubleUps count.
        /// </summary>
        public TMP_Text doubleUpsCount;

        /// <summary>
        /// Reference to the Image component for the level icon.
        /// </summary>
        public Image levelIcon;

        /// <summary>
        /// Reference to the Toggle UI element for enabling/disabling object destruction.
        /// </summary>
        public Toggle bombsToggle;

        /// <summary>
        /// Reference to the Toggle UI element for enabling/disabling doubling points.
        /// </summary>
        public Toggle doubleUpsToggle;

        /// <summary>
        /// Function that initializes values at the beggining of the game at start toggle listener
        /// </summary>
        void Start()
        {
            // Set the player's nickname in the HUD
            nicknameText.text = DataManager.Instance.nickName;

            // Set the level icon in the HUD
            levelIcon.sprite = DataManager.Instance.difficultyLevel.icon;

            // Set the initial bomb count in the HUD
            bombsCount.text = "Liczba bomb: " + DataManager.Instance.difficultyLevel.startBombsCount.ToString();

            // Set the initial bomb count in the HUD
            doubleUpsCount.text = "Liczba podwojeń: " + DataManager.Instance.difficultyLevel.startDoubleUpsCount.ToString();

            // Set the initial points in the HUD
            pointsText.text = "Punkty: 0";

            // Set the initial cards in hand in the HUD
            cardsText.text = "Karty na ręce: " + DataManager.Instance.difficultyLevel.startCardsCount.ToString();

            // Set the initial cards in deck in the HUD
            //cardsInDeckText.text = "Karty w talii: " + GameBoardController.Instance.cardList.CardCount().ToString();

            // Listen to the toggle's state change event
            bombsToggle.onValueChanged.AddListener(OnBombsToggleValueChanged);
            doubleUpsToggle.onValueChanged.AddListener(OnDoubleUpsToggleValueChanged);

            // Initialize the number of bombs left
            GameBoardController.Instance.bombsLeft = DataManager.Instance.difficultyLevel.startBombsCount;
            GameBoardController.Instance.doubleUpsLeft = DataManager.Instance.difficultyLevel.startDoubleUpsCount;
            GameBoardController.Instance.cardsLeft = DataManager.Instance.difficultyLevel.startCardsCount;
            //GameBoardController.Instance.cardsLeftInDeck = GameBoardController.Instance.cardList.CardCount();
            GameBoardController.Instance.points = 0;
        }
        /// <summary>
        /// // Update the bomb count in the HUD
        /// </summary>
        private void Update()
        {
            // Update the bomb count in the HUD
            bombsCount.text = "Liczba bomb:" + GameBoardController.Instance.bombsLeft.ToString();

            // Update the doubleUps count in the HUD
            doubleUpsCount.text = "Liczba podwojeń:" + GameBoardController.Instance.doubleUpsLeft.ToString();

            // Update the points in the HUD
            pointsText.text = "Punkty:" + GameBoardController.Instance.points.ToString();

            // Update the cards in hand in the HUD
            cardsText.text = "Karty na ręce:" + GameBoardController.Instance.cardsLeft.ToString();

            // Update the cards in deck in the HUD
            cardsInDeckText.text = "Karty w talii:" + GameBoardController.Instance.cardsLeftInDeck.ToString();
        }

        /// <summary>
        /// Handles the event when the toggle for enabling/disabling building destruction is changed.
        /// </summary>
        /// <param name="value">The new value of the toggle (true or false).</param>
        private void OnBombsToggleValueChanged(bool value)
        {
            // Enable or disable object destruction based on the toggle state
            GameBoardController.Instance.canDestroy = value;
        }

        // <summary>
        /// Handles the event when the toggle for enabling/disabling points doubling is changed.
        /// </summary>
        /// <param name="value">The new value of the toggle (true or false).</param>
        private void OnDoubleUpsToggleValueChanged(bool value)
        {
            Debug.Log($"value: {value}");
            // Enable or disable points doubling based on the toggle state
            GameBoardController.Instance.canDoublePoints = value;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    /// Reference to the Text Mesh Pro (TMP) text component for bomb count.
    /// </summary>
    public TMP_Text bombCount;

    /// <summary>
    /// Reference to the Image component for the level icon.
    /// </summary>
    public Image levelIcon;

    /// <summary>
    /// Reference to the Toggle UI element for enabling/disabling object destruction.
    /// </summary>
    public Toggle toggle;

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
        bombCount.text = "Liczba bomb:" + DataManager.Instance.difficultyLevel.bombCount.ToString();

        // Listen to the toggle's state change event
        toggle.onValueChanged.AddListener(OnToggleValueChanged);

        // Initialize the number of bombs left
        GameBoardController.Instance.bombsLeft = DataManager.Instance.difficultyLevel.bombCount;
    }
    /// <summary>
    /// // Update the bomb count in the HUD
    /// </summary>
    void Update()
    {
        // Update the bomb count in the HUD
        bombCount.text = "Liczba bomb:" + GameBoardController.Instance.bombsLeft.ToString();
    }

    /// <summary>
    /// Handles the event when the toggle for enabling/disabling building destruction is changed.
    /// </summary>
    /// <param name="value">The new value of the toggle (true or false).</param>
    private void OnToggleValueChanged(bool value)
    {
        // Enable or disable object destruction based on the toggle state
        GameBoardController.Instance.canDestroy = value;
    }
}

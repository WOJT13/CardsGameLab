using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HudManager : MonoBehaviour
{
    public TMP_Text nicknameText;
    public TMP_Text bombCount;
    public Image levelIcon;
    public Toggle toggle;

    void Start()
    {
        Debug.Log(DataManager.Instance.nickName);
        nicknameText.text = DataManager.Instance.nickName;
        levelIcon.sprite = DataManager.Instance.difficultyLevel.icon;
        bombCount.text = "Liczba bomb:" + DataManager.Instance.difficultyLevel.bombCount.ToString();

        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        GameBoardController.Instance.bombsLeft = DataManager.Instance.difficultyLevel.bombCount;
    }

    // Update is called once per frame
    void Update()
    {
        bombCount.text = "Liczba bomb:" + GameBoardController.Instance.bombsLeft.ToString();
    }

    private void OnToggleValueChanged(bool value)
    {
        if (value == true)
            GameBoardController.Instance.canDestroy = true;
        else
            GameBoardController.Instance.canDestroy = false;

    }

}

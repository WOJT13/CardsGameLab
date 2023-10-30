using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HudManager : MonoBehaviour
{
    public TMP_Text nicknameText;
    public TMP_Text bombCount;
    public Image levelIcon;
    void Start()
    {
        Debug.Log(DataManager.Instance.nickName);
        nicknameText.text = DataManager.Instance.nickName;
        levelIcon.sprite = DataManager.Instance.difficultyLevel.icon;
        bombCount.text = "Liczba bomb:" + DataManager.Instance.difficultyLevel.bombCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

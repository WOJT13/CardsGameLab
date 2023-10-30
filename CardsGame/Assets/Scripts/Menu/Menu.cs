using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TMP_InputField nickInputField;
    public void OnStartButtonClick()
    {
        DataManager.Instance.nickName = nickInputField.text;
        if(!string.IsNullOrWhiteSpace(DataManager.Instance.nickName) && !string.IsNullOrWhiteSpace(DataManager.Instance.difficultyLevel.name))
        {
            SceneManager.LoadScene(0);
        }
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void onPlayAgainButtonClick()
    {
        DataManager.Instance.difficultyLevel = null;
        SceneManager.LoadScene(1);
    }

    public void onQuitButtonClick()
    {
        Application.Quit();
    }
}

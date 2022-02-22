using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public string userName;
    public TMP_InputField inputField;
    public TMP_Text text;

    public void Start()
    {
        ScoreManager.Instance.LoadScoreName();
        text.text = "Best Score: " + ScoreManager.Instance.scoreName + " : " + ScoreManager.Instance.highestScore;
    }

    public void StartGame()
    {
        if (inputField.text == "")
            Debug.Log("Write your name");
        else
        {
            ScoreManager.Instance.SetCurrentName(inputField.text);
            userName = inputField.text;
            SceneManager.LoadScene(1);
        }
    }
}

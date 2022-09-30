using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScene : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject usernamePanel;
    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI alertUsernameFail;

    public void StartGame()
    {

        if (gameManager.GetComponent<GameManager>().firstTimePlaying)
        {
            usernamePanel.SetActive(true);
        }
        else
        {

        }
    }

    public void ConfirmUsername()
    {
        if (usernameText.text.Length > 3 && usernameText.text.Length < 16)
        {
            gameManager.GetComponent<UserMB>().SetUserName(usernameText.text);
            SceneManager.LoadScene(2);
        }
        else
        {
            StartCoroutine(InvalidUsername());
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator InvalidUsername()
    {
        alertUsernameFail.text = "Username must contains between 3 and 15 characters";
        yield return new WaitForSecondsRealtime(3);
        alertUsernameFail.text = "";
    }

}

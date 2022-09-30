using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    public GameObject gameManager;
    string language;
    public TextAsset ENlanguageJSON;
    public TextAsset ESlanguageJSON;
    //TEXT ON MENU
    public TextMeshProUGUI startButton;
    public TextMeshProUGUI settingButton;
    public TextMeshProUGUI quitButton;

    Language lang;



    private void Start()
    {
        language = gameManager.GetComponent<GameManager>().language;
        SetLanguageOnMenu();
    }

    public void SetLanguageOnMenu()
    {
        if (language == "en")
        {
            lang = JsonUtility.FromJson<Language>(ENlanguageJSON.text);
            startButton.text = lang.startButton;
            settingButton.text = lang.configButton;
            quitButton.text = lang.quitButton;
        }
        else
        {
            lang = JsonUtility.FromJson<Language>(ESlanguageJSON.text);
            startButton.text = lang.startButton;
            settingButton.text = lang.configButton;
            quitButton.text = lang.quitButton;
        }
    }
}

public class Language
{
    public string startButton;
    public string configButton;
    public string quitButton;

}

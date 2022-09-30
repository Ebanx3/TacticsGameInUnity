using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Crea usuario
    public string language = "en"; //en or es
    public bool connectedToMasterServer = false;
    public bool firstTimePlaying = true;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeLanguage()
    {
        if (language == "en") language = "es";
        else language = "en";
    }

}

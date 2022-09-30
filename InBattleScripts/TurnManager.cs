using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class TurnManager : MonoBehaviour
{
    private static TurnManager _instance;
    public TurnManager Instance { get { return _instance; } }

    public TextMeshProUGUI timerTMP;
    public TextMeshProUGUI activeUserTMP;

    public int activePlayer = 1;

    public int turnNumber = 0;

    public int turnSeconds = 30;
    public int secondsToStartBattle = 5;

    bool turnChanged = true;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Update()
    {
        if (turnChanged)
        {
            StartCoroutine(TurnTimeControl());
            turnChanged = false;
        }
    }

    IEnumerator TurnTimeControl()
    {
        turnNumber++;
        Debug.Log(turnNumber);
        if (turnNumber == 1)
        {
            for (int t = secondsToStartBattle; t > 0; t--)
            {
                timerTMP.text = t.ToString();
                yield return new WaitForSecondsRealtime(1);
            }
            MapManager.Instance.SetStartingTilesVIsible(turnNumber);

        }
        else if (turnNumber == 2)
        {
            MapManager.Instance.SetStartingTilesVIsible(turnNumber);
        }
        for (int t = turnSeconds; t > 0; t--)
        {
            timerTMP.text = t.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        turnChanged = true;
        if (activePlayer == 1) activePlayer = 2;
        else activePlayer = 1;
        activeUserTMP.text = activePlayer.ToString();

    }


}

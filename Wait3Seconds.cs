using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait3Seconds : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Wait2Sec());
    }

    IEnumerator Wait2Sec()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(1);
    }

}

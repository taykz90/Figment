using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSettings : MonoBehaviour
{
    public string nextScene = "MainMenu";

    // Use this for initialization
    IEnumerator Start()
    {
        while (!GameSettings.Instance.IsReady)
        {
            yield return null;
        }

        //SceneManager.LoadScene(nextScene);
    }
}

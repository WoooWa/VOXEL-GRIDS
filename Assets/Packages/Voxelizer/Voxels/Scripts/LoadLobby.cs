using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLobby : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image LoadBar;
    public Text BarText;
    public int ScenID;

    void Start()
    {
        StartCoroutine(LoadSceneCor());
    }

    IEnumerator LoadSceneCor()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(ScenID);
        while(!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            LoadBar.fillAmount = progress;
            BarText.text = "«¿√–”« ¿  " + string.Format("{0:0}", progress * 100f);
            yield return 0;
        }
    }
}

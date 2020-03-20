using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public float[] posicion;
    GameMaster juego;
    public GameObject loadingScreen;
    public Slider slider;
    public void LoadLever(int sceneIndex)
    {
        StartCoroutine(LoadAsynch(sceneIndex));
    }

    IEnumerator LoadAsynch(int sceneIndex) {
        new WaitForSeconds(10f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
       
        while (!operation.isDone)
        {
            float prog = Mathf.Clamp01(operation.progress / .9f);
            slider.value = prog;
            yield return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(1.5f);
    }

    public void NextScene()
    {
        juego.SetClonePlayerPosition(posicion[0], posicion[1]);
        juego.SavePlayer();
    }
    
}

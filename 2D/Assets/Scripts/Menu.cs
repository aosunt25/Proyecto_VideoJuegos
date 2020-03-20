using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
  
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Continuar()
    {
       
      
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}

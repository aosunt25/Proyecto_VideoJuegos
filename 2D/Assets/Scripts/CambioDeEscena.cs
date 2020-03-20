using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public float[] posicion;
  
    public void cambioEscena(int escena)
    {
        SceneManager.LoadScene(escena);

        
    }
    
}

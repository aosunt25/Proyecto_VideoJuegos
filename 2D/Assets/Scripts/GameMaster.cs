using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    public GameObject menu;
    public GameObject cpu;
    public GameObject sotano;
    public GameObject cpu2;
    public GameObject cpu3;
    public static float[] posicion;
    public ControladorDeCamara camara;
    public Inventario inventario;
    public EscritoDeCarta textoCartas;
    public EscritoDeCarta cartasInventario;
    public GameObject player;
    public GameObject cloneplayer;
    public Text presionaE;
    public Text presionaF;
    private bool activarF = false;
    public GameObject[] menusCanvas;
    public Cartas[] cartasDestruir;
    public static int[] cartasActivar;
    public static int[] arregloDeCartas;
    public int totalDeCartas;
    public static int cartasRecogidas = 0;
    public Text contadorDeCarta;
    public static GameMaster instance = null;
    public int escenaActual;
    public float[] posicionInicialSiguienteActo;
    void Awake()
    {

        Setup();
        escenaActual = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }
    public void Setup()
    {
        InformacionDeJugar data = SavingSystem.CargarJugador();
        if (data == null)
        {
            cloneplayer = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
            cartasActivar = new int[30];
        }
        else
        {
            Vector2 pos;
            pos.x = data.posicion[0];
            pos.y = data.posicion[1];
            transform.position = pos;
            cartasActivar = data.cartasActivarInventario;
            cloneplayer = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
            for (int i = 0; i < cartasRecogidas; i++)
            {

                ActivarInventario(data.cartasActivarInventario[i]);
                CartasDestruir(data.cartasActivarInventario[i]);


            }
        }
        
        
    }
    public GameObject GetClonePLayere()
    {
        return cloneplayer;
    }
    // Start is called before the first frame update
    void Start()
    {
        contadorDeCarta.text = "CARTAS " + cartasRecogidas + "/" + totalDeCartas;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                menu.gameObject.SetActive(true);
            }
            else
            {
                DesactivarMenusCanvas();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                inventario.ActivarInventario();
                presionaF.gameObject.SetActive(false);
                activarF = true;
            }
            else
            {
                DesactivarMenusCanvas();
            }

        }
        if (cartasRecogidas == 10 && escenaActual == 1)
        {
            cpu.SetActive(true);
        }
        if (cartasRecogidas == 29)
        {
            sotano.SetActive(true);
        }
        if (cartasRecogidas == 20 && escenaActual==3)
        {
            cpu2.SetActive(true);
        }
        if (cartasRecogidas == 30)
        {
            cpu3.SetActive(true);
        }
    }
    public void contadorDeCartas()
    {
        cartasRecogidas++;
        contadorDeCarta.text = "CARTAS " + cartasRecogidas + "/" + totalDeCartas;
    }

    public int GetCartas()
    {
        int cartas = cartasRecogidas;
        return cartas;
    }

    public void MoverCamara()
    {
        camara.transform.position = new Vector3(0, 0, 0);
    }
    public void SavePlayer()
    {
        SavingSystem.SavePlayer(this);
    }
    public void PlayGame()
    {
        
        if (SavingSystem.CargarJugador() != null)
        {
            InformacionDeJugar data = SavingSystem.CargarJugador();
            SceneManager.LoadScene(data.acto);
            cartasRecogidas = data.cartas;
        }
        else
        {
            SceneManager.LoadScene(1);
            cartasRecogidas = 0;
        }   
       
       

    }
    public void QuitGame()
    {
        SavingSystem.SavePlayer(this);
        SceneManager.LoadScene(0);
    }
    public void SiguienteEscena(int e)
    {
        Vector2 pos;
        pos.x = posicionInicialSiguienteActo[0];
        pos.y = posicionInicialSiguienteActo[1];
        if (cloneplayer.transform.position != null)
        {
            cloneplayer.transform.position = pos;
        }
        else
        {
            cloneplayer = Instantiate(player, pos, Quaternion.identity) as GameObject;
        }
            
        escenaActual += 2;
        SavingSystem.SavePlayer(this);
        SceneManager.LoadScene(e);
    }

    public void Continuar()
    {
        if (cartasRecogidas == 1)
        {
            ActivarTextoF();

        }
        Time.timeScale = 1;
        menu.gameObject.SetActive(false);
        inventario.gameObject.SetActive(false);
    }

    public void CartasRecogidas(int carta)
    {
        inventario.ActivarBoton(carta);
        cartasActivar[cartasRecogidas-1] = carta;
    }

    public void ActivarTexto(int carta)
    {
        textoCartas.ActivarTexto(carta);
    }

    public void ActivarPresionarE()
    {
        presionaE.gameObject.SetActive(true);
    }

    public void DesactivarPresioneE()
    {
        presionaE.gameObject.SetActive(false);
    }

    public void ActivarTextoF()
    {
        if (!activarF)
        {
            presionaF.gameObject.SetActive(true);
        }
        else
        {
            Destroy(presionaF);
        }
    }

    public void DesactivarMenusCanvas()
    {
        for (int i = 0; i < menusCanvas.Length; i++)
        {
            menusCanvas[i].SetActive(false);
        }
        textoCartas.Continuar();
        cartasInventario.Continuar();
        Continuar();
    }

    public float GetClonePlayerPositionX()
    {
        return cloneplayer.transform.position.x;
    }

    public float GetClonePlayerPositionY()
    {
        return cloneplayer.transform.position.y;
    }

    public void SetClonePlayerPosition(float x, float y)
    {
        Vector2 pos;
        pos.x = x;
        pos.y = y;
        transform.position = pos;
    }

    public void ActivarInventario(int carta)
    {
        inventario.ActivarBoton(carta);
    }

    public int[] CartasaActivar() 
    {
        return cartasActivar;
    }
    public void CartasDestruir(int numObjeto)
    {
        for(int i=0; i < cartasDestruir.Length; i++)
        {
            if (cartasDestruir[i].numDeCarta == numObjeto)
            {
                cartasDestruir[i].Destruir();
            }
        }
    }

    public void SalirDelJuego()
    {
        cartasRecogidas = 0;
        SavingSystem.DeleteFile();
        SceneManager.LoadScene(0);
    }

   
}

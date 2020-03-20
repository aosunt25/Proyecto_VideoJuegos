using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cartas : MonoBehaviour
{
    [SerializeField]
    // private Text botonParaRecoger;
    public GameObject texto;
    private bool recogerPermitir;
    public int numDeCarta;
    public  Cartas instance = null;
    // Start is called before the first frame update
    private void Start()
    {
       // botonParaRecoger.gameObject.SetActive(false);
    }
    void Awake()
    {

       
        
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        if(recogerPermitir && Input.GetKeyDown(KeyCode.E))
        {
            Recoger();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameMaster.instance.GetClonePLayere())
        {
           // botonParaRecoger.gameObject.SetActive(true);
            recogerPermitir = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameMaster.instance.GetClonePLayere())
        {
           // botonParaRecoger.gameObject.SetActive(false);
            recogerPermitir = false;
        }
    }
    private void Recoger()
    {
        
        texto.gameObject.SetActive(true);
        Destroy(gameObject);
        GameMaster.instance.contadorDeCartas();
        GameMaster.instance.CartasRecogidas(numDeCarta);
        GameMaster.instance.ActivarTexto(numDeCarta);
        Time.timeScale = 0;
    }
    public void Destruir()
    {
        Destroy(gameObject);
    }
    
}

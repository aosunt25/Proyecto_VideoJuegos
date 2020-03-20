using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosConInteraccion : MonoBehaviour
{
    public GameObject carta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameMaster.instance.GetClonePLayere())
        {
            if(carta!=null)
                carta.SetActive(true);
        }
    }
    

}

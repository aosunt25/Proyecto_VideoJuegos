using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limite : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject== GameMaster.instance.GetClonePLayere())
        {
            GameMaster.instance.MoverCamara();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

public class Puertas : MonoBehaviour
{
    public GameObject target;
    bool start = false;
    bool isFadeIn = false;
    float alpha = 0;
    float fadeTime = 1.5f;

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject== GameMaster.instance.GetClonePLayere())
        {
            collision.GetComponent<Animator>().enabled = false;
            collision.GetComponent<Player>().enabled = false;
            FadeIn();
            yield return new WaitForSeconds(fadeTime-.75f);
            collision.transform.position = target.transform.GetChild(0).transform.position;
            yield return new WaitForSeconds(fadeTime+.75f);
            collision.GetComponent<Animator>().enabled = true;
            collision.GetComponent<Player>().enabled = true;
            FadeOut();

        }
       
    }

    private void OnGUI()
    {
        if (!start)
            return;

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        if (isFadeIn)
        {
            alpha=Mathf.Lerp(alpha, 1.1f, fadeTime * Time.deltaTime);
        }
        else
        {
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime);

            if (alpha < 0) start = false;
        }
    }
    void FadeIn()
    {
        start = true;
        isFadeIn = true;
    }
    void FadeOut()
    {
        isFadeIn = false;
    }

}

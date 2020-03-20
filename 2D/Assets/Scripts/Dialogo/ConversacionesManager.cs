using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConversacionesManager : MonoBehaviour
{
    public int NumDeSiguienteEscena;
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogoCanvas;

    public Animator animator;
    private Queue<string> oraciones;
    
     void Start()
    {
        oraciones = new Queue<string>();
    }
    public void StartDialogo(Oraciones oracion)
    {
        dialogoCanvas.SetActive(true);
        animator.SetBool("IsOpen", true);

        nameText.text = oracion.name;

        oraciones.Clear();

        foreach (string sentence in oracion.oraciones)
        {
            oraciones.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (oraciones.Count == 0)
        {
            EndDialogue();
            GameMaster.instance.SiguienteEscena(NumDeSiguienteEscena);
            return;
        }

        string sentence = oraciones.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        dialogoCanvas.SetActive(false);
        animator.SetBool("IsOpen", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro_Dialog_Manager : MonoBehaviour
{

    public Text Dialog_Text;

    private Queue<string> Manager_Sentences;

    // Start is called before the first frame update
    void Start()
    {

        Manager_Sentences = new Queue<string>();

    }

    public void Start_Dialouge(Intro_Dialog dialog)
    {

        Manager_Sentences.Clear();

        foreach (string sentence in dialog.Dialog_Sentences)
        {

            Manager_Sentences.Enqueue(sentence);

        }

        Display_Next_Sentence();

    }

    public void Display_Next_Sentence()
    {

        if (Manager_Sentences.Count == 0)
        {

            End_Dialog();
            return;

        }

        string sentence = Manager_Sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(Type_Sentence(sentence));

    }

    IEnumerator Type_Sentence (string sentence)
    {
        Dialog_Text.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            Dialog_Text.text += letter;
            yield return new WaitForSecondsRealtime(0.055f);
        }

    }
    
    void End_Dialog()
    {

        Debug.Log("End");

    }

    
    
}

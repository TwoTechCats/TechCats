using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Dialog_Triger : MonoBehaviour
{
    public Intro_Dialog dialog;

    public void Start()
    {

        Invoke("Trigger_Dialogue", 2f);

    }


    public void Trigger_Dialogue()
    {

        FindObjectOfType<Intro_Dialog_Manager>().Start_Dialouge(dialog);

        Invoke("Invoce_Next", 15f);


    }

    private void Invoce_Next()
    {

        FindObjectOfType<Intro_Dialog_Manager>().Display_Next_Sentence();

        Invoke("Invoce_Next", 15f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{

    public GameObject[] Spawn_Points;

    public GameObject Mine;
    public GameObject Safe_Place;
    public int Mine_Number;

    int Spawn_Mines = 0;
    int Spawn_Safe = 0;
    int RandomNumber;
    Vector2 Spawn_Location;
    bool Set_Mines = false;

    // Start is called before the first frame update
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {
        

        if(Set_Mines && Spawn_Mines < Mine_Number)
        {

            RandomNumber = Random.Range(0, Spawn_Points.Length);
            Spawn_Location = Spawn_Points[RandomNumber].transform.position;

            Instantiate(Mine, Spawn_Location, transform.rotation);

            Spawn_Mines = Spawn_Mines + 1;

        }
        
        if(Spawn_Safe < Spawn_Points.Length)
        {

            Instantiate(Safe_Place, Spawn_Points[Spawn_Safe].transform.position, transform.rotation);
            Spawn_Safe = Spawn_Safe + 1;

        }

        if(Spawn_Safe == Spawn_Points.Length)
        {

            Set_Mines = true;

        }

    
    }
}

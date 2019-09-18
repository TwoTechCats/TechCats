using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{

    public GameObject[] Spawn_Points;
    public GameObject Mine;
    public GameObject Safe_Place;
    public int Mine_Number;
    public GameObject Danger_Number_3;
    public GameObject Danger_Number_2;
    public GameObject Danger_Number_1;

    int Spawn_Mines = 0;
    int Spawn_Safe = 0;
    int RandomNumber;

    Vector2 Spawn_Location;
    Collider2D Test;
    Collider2D Col;
    Collider2D Col_1;
    Collider2D Col_2;

    GameObject Object_1;
    GameObject Object_2;
    public GameObject Start_Panel;

    bool Set_Mines = false;
    bool Mines_Placed = false;
    bool Count_Start = false;
    bool Number_Set = false;
   

    // Start is called before the first frame update
    void Start()
    {

        Invoke("Panel", 5f);

    }

    // Update is called once per frame
    void Update()
    {
        

        if(Spawn_Mines < Mine_Number)
        {

            RandomNumber = Random.Range(0, Spawn_Points.Length);

            Test = Physics2D.OverlapPoint(Spawn_Points[RandomNumber].transform.position);

            if(Test == null)
            {

            Spawn_Location = Spawn_Points[RandomNumber].transform.position;

            Instantiate(Mine, Spawn_Location, transform.rotation);

            Spawn_Mines = Spawn_Mines + 1;

            }
            

        }

        if(Spawn_Mines == Mine_Number)
        {

            Mines_Placed = true;

        }
        
        if(Spawn_Safe < Spawn_Points.Length && Number_Set == true)
        {

            Instantiate(Safe_Place, Spawn_Points[Spawn_Safe].transform.position, transform.rotation);
            Spawn_Safe = Spawn_Safe + 1;
            

        }
        
        if(Mines_Placed == true && Count_Start == false)
        {
            Mines_Placed = false;
            Count_Start = true;

            for (int i = 0; i < Spawn_Points.Length; i++)
            {
                if( i == Spawn_Points.Length - 1)
                {
                    Number_Set = true;
                }

                Col = Physics2D.OverlapPoint(Spawn_Points[i].transform.position);

                if(Col != null)
                {

                    if (Col.tag == "Mines")
                    {

                        Instantiate(Danger_Number_3, Spawn_Points[i].transform.position, transform.rotation);

                        
                        
                    }



                }

                if(Col == null)
                {

                    Col_1 = Physics2D.OverlapCircle(Spawn_Points[i].transform.position, 1.2f);

                    if (Col_1 != null)
                    {

                        if (Col_1.tag == "Mines")
                        {

                            Instantiate(Danger_Number_2, Spawn_Points[i].transform.position, transform.rotation);

                        }



                    }

                    if(Col_1 == null)
                    {

                        Instantiate(Danger_Number_1, Spawn_Points[i].transform.position, transform.rotation);


                    }

                }


            }

        }

    
    }

    private void Panel()
    {

        Start_Panel.SetActive(false);

    }
}

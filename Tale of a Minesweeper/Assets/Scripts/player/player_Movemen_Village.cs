using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_Movemen_Village : MonoBehaviour
{

    Collider2D col;
    Collider2D Touched_Col;
    Vector2 touchPosition;
    public int speed = 3;
    public GameObject Player;

    bool Movement = true;
    bool Can_Move = false;

    public Text Naziv;
    public GameObject Title;
    public GameObject Od_Kovaca;
    public GameObject Od_Travara;

    // Start is called before the first frame update
    void Start()
    {
        col.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement == true && Input.touchCount > 0)
        {


            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Touched_Col = Physics2D.OverlapPoint(touchPosition);

            Can_Move = true;

            //transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);

        }

        if(Movement == true && Can_Move == true)
        {

            transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);

        }

        if((Vector2)transform.position == touchPosition)
        {

            Can_Move = false;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Movement = false;
        Invoke("Resum_Movement", 2f);

        if(collision.tag == "Kovac")
        {
            Title.SetActive(true);
            Naziv.text = "Kovac";
            Player.transform.position = Touched_Col.transform.position;
            touchPosition = Od_Kovaca.transform.position;

        }

        if(collision.tag == "Travar")
        {
            Title.SetActive(true);
            Naziv.text = "Travar";
            Player.transform.position = Touched_Col.transform.position;
            touchPosition = Od_Travara.transform.position;

        }

        if(collision.tag == "Level")
        {

            SceneManager.LoadScene(1);

        }

        if(collision.tag == "MainMenu")
        {

            SceneManager.LoadScene("Main_Menu");

        }

    }

    private void Resum_Movement()
    {
        Title.SetActive(false);
        Movement = true;

    }

}

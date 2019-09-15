using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TapToMove : MonoBehaviour
{

    bool CanMove = false;
    bool Dead = false;
    Collider2D col;
    public Collider2D Planet_Collider;
    Collider2D touchedCollider;
    Vector2 MoveTO;


    public GameObject Health_1;
    public GameObject Health_2;
    public GameObject Health_3;

    int Health = 1;
    public SpriteRenderer Player_Color;
    public GameObject Damage_Effect;


    public Animation GameOver_Anim;
    public GameObject Restart_Btn;
    public GameObject Quit_Btn;
    public GameObject Back_To_Village_btn;
    Vector2 touchPosition;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

        col = GetComponent<Collider2D>();
        Damage();

    }

    // Update is called once per frame
    void Update()
    {

        if (CanMove == false && Input.touchCount > 0 && Dead == false)
        {

            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);


            touchedCollider = Physics2D.OverlapPoint(touchPosition);
            



            CanMove = true;
            Planet_Collider.enabled = false;

        }
        
        if(CanMove == true && Dead == false)
        {

            //transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);
            MoveTO = touchedCollider.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, MoveTO, speed * Time.deltaTime);
            

        }

        if((Vector2)transform.position == MoveTO )
        {

            CanMove = false;

            Planet_Collider.enabled = true;

        }

        

    }

    public void Death()
    {

        Health = Health - 1;
        Damage_Effect_Screen_Activate();
        Damage();

        if (Health == 0)
        {
            Dead = true;
            Player_Color.color = new Color(0.5f, 0, 0);
            GameOver_Anim.Play();
            Restart_Btn.SetActive(true);
            Quit_Btn.SetActive(true);
            Back_To_Village_btn.SetActive(true);

        }
    }

    private void Damage()
    {

        if(Health == 3)
        {

            Health_1.SetActive(true);
            Health_2.SetActive(true);
            Health_3.SetActive(true);

        }
        if(Health == 2)
        {

            Health_1.SetActive(true);
            Health_2.SetActive(true);
            Health_3.SetActive(false);

        }
        if(Health == 1)
        {

            Health_1.SetActive(true);
            Health_2.SetActive(false);
            Health_3.SetActive(false);

        }
        if(Health == 0)
        {

            Health_1.SetActive(false);
            Health_2.SetActive(false);
            Health_3.SetActive(false);

        }

    }

    private void Damage_Effect_Screen_Activate()
    {

        Damage_Effect.SetActive(true);
        Invoke("Damage_EffectAsreen_Deactivate", .3f);

    }
    private void Damage_EffectAsreen_Deactivate()
    {

        Damage_Effect.SetActive(false);

    }

}

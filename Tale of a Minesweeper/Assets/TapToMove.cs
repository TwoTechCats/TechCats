using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TapToMove : MonoBehaviour
{

    bool CanMove = false;
    bool Dead = false;
    bool Start_Game = false;

    bool Lounch = false;
    int x, y;
    Vector2 Num_x;



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
    private bool Seting_falg = false;
    public GameObject Flag;
    private Touch touch;
    private Vector2 Flag_Position;
    private Collider2D Flag_Col;
    

    // Start is called before the first frame update
    void Start()
    {

        col = GetComponent<Collider2D>();
        Damage();
        Invoke("Beguin_Movement", 2.5f);

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Start_Game == true && CanMove == false && Input.touchCount > 0 && Dead == false)
        {

            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);


            touchedCollider = Physics2D.OverlapPoint(touchPosition);

            if (touchedCollider != null)
            {
                CanMove = true;
                Planet_Collider.enabled = false;
            }
        }
        
        if(CanMove == true && Dead == false)
        {

            //transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);
            
            if (touchedCollider.tag == "Move_Point" || touchedCollider.tag == "Mines")
            {
                    MoveTO = touchedCollider.transform.position;
                    transform.position = Vector2.MoveTowards(transform.position, MoveTO, speed * Time.deltaTime);

            }
                        
        }

        if((Vector2)transform.position == MoveTO )
        {

            CanMove = false;

            Planet_Collider.enabled = true;

        }

        if (Lounch)
        {

            transform.position = Vector2.MoveTowards(transform.position, Num_x, 15 * Time.deltaTime);

        }

        if(Seting_falg == true && Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            Flag_Position = Camera.main.ScreenToWorldPoint(touch.position);
            Flag_Col = Physics2D.OverlapPoint(Flag_Position);

            Spawn_Flag();
            Seting_falg = false;

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

            Invoke("Lounch_Player", 1.2f);

            Invoke("End", 2.5f);

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

    private void End()
    {

        
        GameOver_Anim.Play();
        Restart_Btn.SetActive(true);
        Quit_Btn.SetActive(true);
        Back_To_Village_btn.SetActive(true);

    }

    private void Lounch_Player()
    {

        x = Random.Range(-2, 2);
        y = Random.Range(-2, 2);

        Num_x = new Vector2(transform.position.x + x, transform.position.y + y);

        Lounch = true;

    }

    private void Beguin_Movement()
    {
        Start_Game = true;
    }

    public void Set_Flag()
    {

        Invoke("Flag_Btn", .5f);

    }

    private void Spawn_Flag()
    {

        Instantiate(Flag, Flag_Col.transform.position, transform.rotation);
        Invoke("Flage_Btn_Off", 0.5f);

    }

    private void Flag_Btn()
    {

        Seting_falg = true;
        CanMove = true;
        Dead = true;

    }

    private void Flage_Btn_Off()
    {

        CanMove = false;
        Dead = false;

    }

}

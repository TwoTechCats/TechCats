using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineActivate : MonoBehaviour
{

    public SpriteRenderer Sprite;
    public SpriteRenderer Player_Color;
    public GameObject Player;
    private TapToMove Script;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Planet");
        Player_Color = Player.GetComponent<SpriteRenderer>();
        Script = Player.GetComponent<TapToMove>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Planet")
        {
           Sprite.color = new Color(1, 1, 1, 1);

            Play_Anim();
            //Player_Color.color = new Color(0.5f, 0, 0);

            Script.Death();
        }

    }

    private void Play_Anim()
    {

        anim.SetBool("Boom", true);
        Invoke("Anim_Stop", 1.5f);

    }

    private void Anim_Stop()
    {

        Destroy(this.gameObject);

    }

}

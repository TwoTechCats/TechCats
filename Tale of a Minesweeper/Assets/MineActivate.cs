using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineActivate : MonoBehaviour
{

    public SpriteRenderer Sprite;
    public SpriteRenderer Player_Color;
    public GameObject Player;
    private TapToMove Script;

    // Start is called before the first frame update
    void Start()
    {

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
           Sprite.color = new Color(1, 0, 0);

           
            //Player_Color.color = new Color(0.5f, 0, 0);

            Script.Death();
        }

    }

}

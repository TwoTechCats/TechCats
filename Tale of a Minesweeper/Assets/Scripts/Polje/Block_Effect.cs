using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Effect : MonoBehaviour
{
    public SpriteRenderer Block;

    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {

        col = Physics2D.OverlapPoint(transform.position);

        if(col.tag == "Mines")
        {

            Mine();

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet")
        {
            Block.color = new Color(0, 1, 0, 0);
        }
    }

    private void Mine()
    {

        Block.color = Color.red;

    }

}

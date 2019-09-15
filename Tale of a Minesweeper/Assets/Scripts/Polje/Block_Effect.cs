using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Effect : MonoBehaviour
{
    public SpriteRenderer Block;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet")
        {
            Block.color = new Color(0, 1, 0, 0);
        }
    }

}

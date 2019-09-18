using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Animation : MonoBehaviour
{

    public Animator Test;
    Vector2 Movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Movement.x = Input.GetAxisRaw("Horizontal");

        if(Movement.x < 0)
        {

            Test.SetBool("Active", true);

        }
        if(Movement.x == 0)
        {

            Test.SetBool("Active", false);

        }

    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{

    public float Min_X;
    public float Max_X;
    public float Min_Y;
    public float Max_Y;

    public float speed;

    Vector2 target_Position;


    // Start is called before the first frame update
    void Start()
    {

        target_Position = Get_Random_position();

    }

    // Update is called once per frame
    void Update()
    {
        
        if((Vector2)transform.position != target_Position)
        {

            transform.position = Vector2.MoveTowards(transform.position, target_Position, speed * Time.deltaTime);

        }
        else
        {
            target_Position = Get_Random_position();
        }

    }

    Vector2 Get_Random_position()
    {

        float Random_X = Random.Range(Min_X, Max_X);
        float Random_Y = Random.Range(Min_Y, Max_Y);

        return new Vector2(Random_X, Random_Y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Planet")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }
}

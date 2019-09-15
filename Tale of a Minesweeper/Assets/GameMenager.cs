using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart_Level()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Quit_To_MainMenu()
    {

        SceneManager.LoadScene(0);

    }

    public void Back_To_Village()
    {

        SceneManager.LoadScene(2);

    }
}

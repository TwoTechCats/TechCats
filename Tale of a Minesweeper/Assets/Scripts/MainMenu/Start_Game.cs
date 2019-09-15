using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin_Game()
    {
        
        SceneManager.LoadScene(1);

    }

    public void Level_Selection()
    {

        SceneManager.LoadScene("Level_Selection");

    }

    public void Village_Enter()
    {

        SceneManager.LoadScene("Village");

    }

}

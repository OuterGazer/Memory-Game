using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{    
    public void VeryEasy()
    {
        SceneManager.LoadScene("Very Easy");
    }

    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }

    public void Intermediate()
    {
        SceneManager.LoadScene("Intermediate");
    }

    public void Difficult()
    {
        SceneManager.LoadScene("Difficult");
    }

    public void Extreme()
    {
        SceneManager.LoadScene("Extreme");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

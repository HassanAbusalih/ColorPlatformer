using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_B : MonoBehaviour
{
    void Start()
    {

    }
    public void Play_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Mnu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void info()
    {
        SceneManager.LoadScene("Information");
    }
    // Update is called once per frame
    void Update()
    {

    }

}

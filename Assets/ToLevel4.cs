using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel4 : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(4);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public bool firstPush = false;

    public void PressStart()
    {
        if (!firstPush)
        {
            SceneManager.LoadScene("Tutorial");
        }
        firstPush = true;
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

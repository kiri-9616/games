using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker_FirstIn : MonoBehaviour
{
    public bool flag = false;
    public bool FirstIn = true;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && FirstIn)
        {
            flag = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && FirstIn)
        {
            flag = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && FirstIn)
        {
            flag = false;
            FirstIn = false;
        }
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

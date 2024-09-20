using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveChecker : MonoBehaviour
{
    public bool isDive = false;
    private bool first = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && first)
        {
            if (first)
            {
                isDive = true;
                first = false;
            }
            else if (!first)
            {
                isDive = false;
            }
        }
    }

    /*public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isDive = false;
        }
    }*/


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

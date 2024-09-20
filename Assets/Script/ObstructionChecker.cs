using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionChecker : MonoBehaviour
{
    public bool isInteract = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isInteract = true;
           
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInteract = false;
          
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstructionController : MonoBehaviour
{
    public ObstructionChecker obst;
    public GameObject TargetText;
    
    private Animator anim = null;
    private Text textS;

    private bool isInteract = false;
    private bool isTanble = false;
    private bool first;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        textS = TargetText.GetComponent<Text>();
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        isInteract = obst.isInteract;

        if (isInteract)
        {
            if (first)
            {
                textS.text = "press S";

                if (Input.GetKey(KeyCode.S))
                {
                    isTanble = true;
                    first = false;
                    textS.text = "";
                }
            }
            else
            {
                isTanble = false;
            }
        }
        else
        {
            textS.text = "";
            isTanble = false;
            
        }

        SetAnimation();

    }

    private void SetAnimation()
    {
        anim.SetBool("tanble", isTanble);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop_Up_Message : MonoBehaviour
{
    public Checker_FirstIn checker;

    [SerializeField]
    private string message = null;

    private Text text;

    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        flag = checker.flag;

        if (flag)
        {
            text.text = message;

        }
        else
        {
            text.text = "";
        }
    }
}

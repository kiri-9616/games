using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_Stageone : MonoBehaviour
{
    [SerializeField]
    private string stage_name = null;


    public void GoNextStage()
    {
        SceneManager.LoadScene(stage_name);
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

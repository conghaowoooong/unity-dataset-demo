using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click(){
        bool autorun = GameObject.Find("DatasetAgents").GetComponent<AllAgentsControllor>().autorun;
        if (!autorun)
        {
            GameObject.Find("DatasetAgents").GetComponent<AllAgentsControllor>().button_click();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAutorun : MultiChooseBox
{
    override public void update_texts()
    {
        name_list = new List<string>{
            "ON",
            "OFF",
        };
        isOn_list = new List<bool>{
            GameObject.Find("DatasetAgents").GetComponent<AllAgentsControllor>().autorun ? true : false,
            GameObject.Find("DatasetAgents").GetComponent<AllAgentsControllor>().autorun ? false : true,
        };
        title_text = "Set Auto Run";
    }

    public override void parameter_custom()
    {
        father_transform = GameObject.Find("Canvas").transform;
    }

    override public void click_custom(){
        
    }

    override public void callbacks_custom(int index)
    {
        switch (index)
        {
            case 0:
                GameObject.Find("DatasetAgents").GetComponent<AllAgentsControllor>().autorun = true;
                GameObject.Find("DatasetAgents").GetComponent<AllAgentsControllor>().start_autorun();
                break;

            case 1:
                GameObject.Find("DatasetAgents").GetComponent<AllAgentsControllor>().autorun = false;
                GameObject.Find("DatasetAgents").GetComponent<AllAgentsControllor>().end_autorun();
                break;

            default:
                break;
        }
    }
}

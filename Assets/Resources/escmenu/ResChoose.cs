using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResChoose : MultiChooseBox
{   
    public GameObject escmenu;
    
    // Start is called before the first frame update
    override public void update_texts()
    {
        name_list = new List<string> {
            "1920*1080 (F)",
            "1920*1080",
            "1600*900",
            "1024*576",
        };
        isOn_list = new List<bool>{
            true,
            false,
            false,
            false,
        };
        title_text = "Choose Resolution";
    }

    public override void parameter_custom()
    {
        father_transform = GameObject.Find("ESCmenu").transform;
        escmenu = GameObject.Find("ESCmenu");
    }

    public override void click_custom()
    {
        escmenu.GetComponent<EscMenuManager>().set_state(false);
    }

    public override void callbacks_custom(int index)
    {
        switch (index)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;

            case 1:
                Screen.SetResolution(1920, 1080, false);
                break;

            case 2:
                Screen.SetResolution(1440, 900, false);
                break;

            case 3:
                Screen.SetResolution(1024, 768, false);
                break;

            default:
                Screen.SetResolution(1920, 1080, true);
                break;
        }

        escmenu.GetComponent<EscMenuManager>().set_state(true);
    }
}

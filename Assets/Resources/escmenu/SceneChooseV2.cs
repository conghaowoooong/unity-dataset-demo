using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChooseV2 : MultiChooseBox
{   
    public GameObject escmenu;

    // Start is called before the first frame update
    override public void update_texts()
    {
        name_list = new List<string>{
            "Social Energy Simulator",
            "ETH-eth",
            "UCY-zara1",
        };
        isOn_list = new List<bool>{
            SceneManager.GetActiveScene().name == "socialenergy" ? true : false,
            SceneManager.GetActiveScene().name == "eth" ? true : false,
            SceneManager.GetActiveScene().name == "zara1" ? true : false,
        };
        title_text = "Choose Scene";
    }

    override public void parameter_custom()
    {
        father_transform = GameObject.Find("ESCmenu").transform;
        escmenu = GameObject.Find("ESCmenu");
    }

    override public void click_custom(){
        escmenu.GetComponent<EscMenuManager>().set_state(false);
    }

    override public void callbacks_custom(int index)
    {
        switch (index)
        {
            case 0:
                SceneManager.LoadScene("socialenergy");
                break;
                
            case 1:
                SceneManager.LoadScene("eth");
                break;

            case 2:
                SceneManager.LoadScene("zara1");
                break;

            default:
                break;
        }

        escmenu.GetComponent<EscMenuManager>().set_state(true);
    }
}

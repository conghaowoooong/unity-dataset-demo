using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCanvas : MultiChooseBox
{
    override public void update_texts()
    {
        name_list = new List<string>{
            "Social Energy Simulator",
            "Dataset Simulator: eth",
            "Dataset Simulator: zara",
        };
        isOn_list = new List<bool>{
            true,
            false,
            false,
        };
        title_text = "Select Scene";
    }

    public override void parameter_custom()
    {
        father_transform = GameObject.Find("IntroCanvas").transform;
    }

    override public void click_custom(){
        this.transform.gameObject.SetActive(false);
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
    }
}

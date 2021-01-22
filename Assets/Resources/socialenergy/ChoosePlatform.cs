using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ChoosePlatform : MultiChooseBox
{
    private GameObject _platform;
    override public void update_texts()
    {
        name_list = new List<string>{
            "Cube",
            "Ball",
            "Person",
            "Person2",
        };
        isOn_list = new List<bool>{
            true,
            false,
            false,
            false,
        };
        title_text = "Select Platform";
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
                destory_platform();
                _platform = GameObject.Instantiate(Resources.Load<GameObject>("socialenergy/cube"));
                _platform.transform.position = new Vector3(15f, 0f, 15f);
                break;

            case 1:
                destory_platform();
                _platform = GameObject.Instantiate(Resources.Load<GameObject>("socialenergy/keng"));
                _platform.transform.position = new Vector3(13.3f, 0f, 14f);
                break;

            case 2:
                destory_platform();
                _platform = new GameObject();
                GameObject npc = GameObject.Instantiate(Resources.Load<GameObject>("DatasetControl/npc"), _platform.transform);
                npc.transform.position = new Vector3(14.2f, 0f, 15f);

                GameObject intention = GameObject.Instantiate(Resources.Load<GameObject>("DatasetControl/intentionball"), _platform.transform);
                intention.transform.position = new Vector3(14.2f, 0f, 15f);
        
                npc.GetComponent<AICharacterControl>().target = intention.transform;
                break;

            case 3:
                destory_platform();
                _platform = new GameObject();
                GameObject npc2 = GameObject.Instantiate(Resources.Load<GameObject>("DatasetControl/npc"), _platform.transform);
                npc2.transform.position = new Vector3(14.2f, 0.5f, 15f);
                npc2.GetComponent<Rigidbody>().isKinematic = true;

                GameObject keng2 = GameObject.Instantiate(Resources.Load<GameObject>("socialenergy/keng2"), _platform.transform);
                keng2.transform.position = new Vector3(13.3f, 0f, 14f);
    
                break;

            default:
                break;
        }
    }

    private void destory_platform(){
        if (_platform)
        {
            GameObject.Destroy(_platform);
        }
    }
}

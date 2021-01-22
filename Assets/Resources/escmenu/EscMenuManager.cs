using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenuManager : MonoBehaviour
{
    private GameObject _black_mask;
    private GameObject _buttons;

    // Start is called before the first frame update
    void Start()
    {
        GameObject this_object = this.transform.gameObject;
        this_object.transform.name = "ESCmenu";
        this_object.AddComponent<RectTransform>();
        this_object.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        this_object.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);

        _black_mask = GameObject.Instantiate(Resources.Load<GameObject>("escmenu/escmenu_backimage"), this.transform);
        _buttons = GameObject.Instantiate(Resources.Load<GameObject>("escmenu/escmenu_buttons"), this.transform);
        Debug.Log("esc menu generated.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_state(bool state)
    {
        _buttons.SetActive(state);
    }
}

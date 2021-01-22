using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EscMenu : MonoBehaviour
{
    private GameObject _menu;
    public bool menu_on;


    // Start is called before the first frame update
    void Start()
    {
        menu_on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escmenu_click();
        }
    }

    public void escmenu_click()
    {
        menu_on = !menu_on;
        if (menu_on)
        {
            _menu = new GameObject();
            _menu.transform.parent = this.transform;
            _menu.AddComponent<EscMenuManager>();
            Time.timeScale = 0;
        }
        else
        {
            GameObject.Destroy(_menu);
            Time.timeScale = 1;
        }
    }
}


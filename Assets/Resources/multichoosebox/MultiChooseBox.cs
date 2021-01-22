using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MultiChooseBox : MonoBehaviour
{
    public float height_step;
    public List<string> name_list;
    public List<bool> isOn_list;
    public string title_text;
    public Transform father_transform;

    private GameObject _menu;
    private GameObject _panel;
    private GameObject _title;
    private GameObject[] _toggles;
    private GameObject _ok_button;

    public int max_count;

    public void init(){
        height_step = 35.0f;
        max_count = 0;
        parameter_custom();
    }

    virtual public void parameter_custom(){
        father_transform = new GameObject().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        init();
        update_texts();
    }

    // Update is called once per frame
    void Update()
    {

    }

    virtual public void update_texts(){
        name_list = new List<string>{
            "example0",
            "example1",
        };
        isOn_list = new List<bool>{
            false,
            true,
        };
        title_text = "Title";
    }

    public void click()
    {
        max_count = name_list.Count;
        click_custom();
        create_choose_boxes(name_list);
    }

    virtual public void click_custom(){

    }
    public int get_choose_box_result()
    {
        int i;
        for (i = 0; i < max_count; i++)
        {
            if (_toggles[i].GetComponent<Toggle>().isOn)
            {
                break;
            }
        }
        return i;
    }

    virtual public void callbacks_custom(int index)
    {
        switch (index)
        {
            default:
                break;
        }
    }

    public void ok_button_click()
    {
        int index = get_choose_box_result();
        // Debug.Log(index);
        callbacks_custom(index);
        update_texts();
        GameObject.Destroy(_menu);
    }

    void create_choose_boxes(List<string> name_list)
    {   
        // Parameters
        float panel_height = (max_count + 0.5f) * height_step;  // panel height
        float top_y = height_step * (max_count - 1) / 2.0f; // 从上到下第一个按钮的中心y

        // Init a void menu
        _menu = new GameObject();
        _menu.transform.parent = father_transform;
        _menu.transform.name = "MultoChooseBoxMenu";
        _menu.AddComponent<RectTransform>();
        _menu.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        _menu.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);

        // Panel
        _panel = GameObject.Instantiate(
            Resources.Load<GameObject>("multichoosebox/multichoosebox_panel"),
            _menu.transform
        );
        _panel.GetComponent<RectTransform>().sizeDelta = new Vector2(400f, panel_height);
        _panel.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);        

        // Title
        _title = GameObject.Instantiate(
            Resources.Load<GameObject>("multichoosebox/multichoosebox_title"),
            _menu.transform
        );
        _title.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, top_y + 1.5f * height_step, 0f);
        _title.GetComponentInChildren<Text>().text = title_text;

        // Toggles
        _toggles = new GameObject[name_list.Count];
        int index = 0;
        foreach (var name in name_list)
        {
            GameObject current_toggle = GameObject.Instantiate(
                Resources.Load<GameObject>("multichoosebox/multichoosebox_toggle"),
                _menu.transform
            );
            current_toggle.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, top_y - index * height_step, 0f);
            current_toggle.GetComponentInChildren<Text>().text = name;
            current_toggle.GetComponent<Toggle>().isOn = isOn_list[index];
            current_toggle.GetComponent<Toggle>().group = _panel.GetComponent<ToggleGroup>();

            _toggles[index] = current_toggle;
            index += 1;
        }

        // OK button
        _ok_button = GameObject.Instantiate(
            Resources.Load<GameObject>("multichoosebox/multichoosebox_button"),
            _menu.transform
        );
        _ok_button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, top_y - (index + 1) * height_step, 0f);
        _ok_button.GetComponent<Button>().onClick.AddListener(ok_button_click);
        _ok_button.GetComponentInChildren<Text>().text = "OK";        
    }
}


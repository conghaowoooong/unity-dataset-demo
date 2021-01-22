using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddNewAgent : MonoBehaviour
{
    public bool appera;

    private string _dataset_name;
    private GameObject _main_camera;
    private GameObject _agent;

    // Start is called before the first frame update
    void Start()
    {
        appera = false;
        _dataset_name = SceneManager.GetActiveScene().name;
        _main_camera = GameObject.Find("Main Camera");
        reset_camera();
        this.GetComponentInChildren<Text>().text = "Add Player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset_camera(){
        if (_dataset_name == "zara1")
        {
            _main_camera.transform.position = new Vector3(16.4f, 10.2f, -1.5f);
            _main_camera.transform.eulerAngles = new Vector3(40f, 0f, 0f);
        }
        if (_dataset_name == "eth")
        {
            _main_camera.transform.position = new Vector3(23.4f, 42.8f, 11.2f);
            _main_camera.transform.eulerAngles = new Vector3(73.3f, -90f, 0f);
        }
        
    }

    public void click(){
        appera = !appera;

        if (appera)
        {
            _agent = GameObject.Instantiate(Resources.Load<GameObject>("DatasetControl/player"));
            _main_camera.AddComponent<CameraFollow>();
            _main_camera.GetComponent<CameraFollow>().target = _agent.transform;
            this.GetComponentInChildren<Text>().text = "Remove Player";
        }
        else
        {
            GameObject.Destroy(_main_camera.GetComponent<CameraFollow>());
            GameObject.Destroy(_agent);
            reset_camera();
            this.GetComponentInChildren<Text>().text = "Add Player";
        }
    }
}

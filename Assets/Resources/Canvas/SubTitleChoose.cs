using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubTitleChoose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string scene_name = SceneManager.GetActiveScene().name;
        string text;
        switch (scene_name)
        {
            case "eth":
                text = "Dataset Simulator: ETH-eth";
                break;

            case "zara1":
                text = "Dataset Simulator: UCY-zara1";
                break;

            case "socialenergy":
                text = "Social Energy: Motivation and Simulation";
                break;
                
            default:
                text = "Sub Title";
                break;
        }
        this.GetComponentInChildren<Text>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
 * @Author: Conghao Wong
 * @Date: 2020-10-07 20:51:38
 * @LastEditors: Conghao Wong
 * @LastEditTime: 2021-01-22 12:52:24
 * @Description: file content
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AgentControllor : MonoBehaviour
{
    public List<Vector3> historical_traj;
    public List<int> frame_list;
    public GameObject npc;
    public GameObject intention;

    // Start is called before the first frame update
    void Start(){
        
    }

    public void init(){
        historical_traj = new List<Vector3>();
        frame_list = new List<int>();

        intention = GameObject.Instantiate(Resources.Load<GameObject>("DatasetControl/intentionball"), this.transform);
        npc = GameObject.Instantiate(Resources.Load<GameObject>("DatasetControl/npc"), this.transform);
        npc.GetComponent<AICharacterControl>().target = intention.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

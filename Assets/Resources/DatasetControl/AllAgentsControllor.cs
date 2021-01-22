/*
 * @Author: Conghao Wong
 * @Date: 2020-10-07 22:31:06
 * @LastEditors: Conghao Wong
 * @LastEditTime: 2021-01-22 12:51:47
 * @Description: file content
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System;

public class AllAgentsControllor : MonoBehaviour
{
    public int frame_index;
    private int list_index;
    public List<List<string>> csv_data;

    public float time_step;
    public int clean_time;
    public List<int> agent_index_list;
    public bool autorun;

    // Start is called before the first frame update
    void Start()
    {
        frame_index = 0;
        list_index = 0;
        clean_time = 30;
        time_step = 0.4f;
        autorun = false;
        agent_index_list = new List<int>();

        string csv_file_name = string.Format("{0}.csv", SceneManager.GetActiveScene().name);
        csv_data = CSVTool.Read(Application.streamingAssetsPath + "/" + csv_file_name, Encoding.Default);   // shape = [4, n]
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start_autorun(){
        InvokeRepeating("button_click", 0f, time_step);
    }

    public void end_autorun(){
        CancelInvoke("button_click");
    }

    public void button_click(){
        update_dataset();
    }

    public void update_dataset(){
        // 超出判断
        if (list_index >= csv_data[0].Count)
        {
            destroy_all_agents();
            list_index = 0;
            frame_index = 0;
        }

        // 寻找下一帧
        while (int.Parse(csv_data[0][list_index]) > frame_index)
        {
            frame_index += 1;
        }

        // 更新agent
        for ( ; int.Parse(csv_data[0][list_index]) == frame_index; list_index++)
        {
            int agent_index_current = int.Parse(csv_data[1][list_index]);

            if (GameObject.Find(string.Format("DatasetAgent{0}", agent_index_current)))
            {
                // 查找agent
                GameObject agent_current = GameObject.Find(string.Format("DatasetAgent{0}", agent_index_current));
                
                Vector3 pos = new Vector3(
                    2f * float.Parse(csv_data[2][list_index]), 
                    0f,
                    2f * float.Parse(csv_data[3][list_index])
                );

                // 更新
                agent_current.GetComponent<AgentControllor>().frame_list.Add(frame_index);
                agent_current.GetComponent<AgentControllor>().historical_traj.Add(pos);
                agent_current.GetComponent<AgentControllor>().intention.transform.position = pos;
            }
            else
            {
                // 新建agent
                GameObject agent_current = new GameObject();
                agent_current.transform.name = string.Format("DatasetAgent{0}", agent_index_current);
                agent_current.transform.parent = this.transform;
                agent_index_list.Add(agent_index_current);

                Vector3 pos = new Vector3(
                    2f * float.Parse(csv_data[2][list_index]), 
                    0f,
                    2f * float.Parse(csv_data[3][list_index])
                );

                // 初始化
                agent_current.AddComponent<AgentControllor>();
                agent_current.GetComponent<AgentControllor>().init();
                agent_current.GetComponent<AgentControllor>().npc.transform.position = pos;
                agent_current.GetComponent<AgentControllor>().intention.transform.position = pos;

                // 更新
                agent_current.GetComponent<AgentControllor>().frame_list.Add(frame_index);
                agent_current.GetComponent<AgentControllor>().historical_traj.Add(pos);
                agent_current.GetComponent<AgentControllor>().intention.transform.position = pos;
            }
        }

        // 检查在线状态
        destroy_offline_agents();
    }

    public void destroy_offline_agents(){
        for (int index = 0; index < agent_index_list.Count; index++)
        {
            GameObject agent = GameObject.Find(string.Format("DatasetAgent{0}", agent_index_list[index]));
            int frame_count = agent.GetComponent<AgentControllor>().frame_list.Count;
            int last_frame = agent.GetComponent<AgentControllor>().frame_list[frame_count - 1];
            if (frame_index - last_frame >= clean_time)
            {
                GameObject.Destroy(agent);
                agent_index_list.Remove(agent_index_list[index]);
            }
        }
    }

    public void destroy_all_agents(){
        for (int index = 0; index < agent_index_list.Count; index++)
        {
            GameObject agent = GameObject.Find(string.Format("DatasetAgent{0}", agent_index_list[index]));
            GameObject.Destroy(agent);
            agent_index_list.Remove(agent_index_list[index]);
        }
    }
}

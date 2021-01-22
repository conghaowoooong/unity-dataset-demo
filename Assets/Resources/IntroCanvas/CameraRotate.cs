using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public int sign;
    public float max_angle;
    public float min_angle;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        sign = 1;
        speed = 0.01f;
        max_angle = 45.0f;
        min_angle = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_angle = this.transform.eulerAngles;
        float new_angle = current_angle[1] + sign * speed;
        this.transform.eulerAngles = new Vector3(current_angle[0], new_angle, current_angle[2]);

        if (new_angle >= max_angle || new_angle <= min_angle)
        {
            sign *= -1;
        }

    }
}

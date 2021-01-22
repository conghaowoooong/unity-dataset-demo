using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllor : MonoBehaviour
{
    public float speed;
    public bool gravity_flag;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        gravity_flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //box moves forward
            gameObject.transform.position = gameObject.transform.position + Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //box moves backward
            gameObject.transform.position = gameObject.transform.position + Vector3.forward * speed * -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //box moves right
            gameObject.transform.position = gameObject.transform.position + Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //box moves left
            gameObject.transform.position = gameObject.transform.position + Vector3.right * speed * -1f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            //box moves left
            gameObject.transform.position = gameObject.transform.position + Vector3.up * speed * 1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            //box moves left
            gameObject.transform.position = gameObject.transform.position + Vector3.up * speed * -1f;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            gravity_flag = !gravity_flag;
            Debug.Log(string.Format("Gravity is {0}.", gravity_flag));
        }

        this.transform.gameObject.GetComponent<Rigidbody>().isKinematic = gravity_flag;
    }
}

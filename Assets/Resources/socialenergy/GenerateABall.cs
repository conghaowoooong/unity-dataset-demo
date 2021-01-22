using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateABall : MonoBehaviour
{
    public Vector3 init_position; 
    private GameObject _ball;
    // Start is called before the first frame update
    void Start()
    {
        init_position = new Vector3(15f, 0.5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click(){
        if (_ball)
        {
            GameObject.Destroy(_ball);
        }

        _ball = GameObject.Instantiate(Resources.Load<GameObject>("socialenergy/GameBall"));
        _ball.transform.position = init_position;
    }
}

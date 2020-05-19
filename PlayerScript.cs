using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("移動速度")] public float speed;
    public GameObject fire;
    private bool Dash = false;
    private bool Masic1 = false;
    private bool Masic2 = false;
    private bool Masic3 = false;
    private int NotDiagonal = 0;//斜め移動防止用
    private Rigidbody rb = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float xspeed = 0;
        float zspeed = 0;
        float horizontalkey = Input.GetAxis("Horizontal");
        float verticalkey = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("g")){
            speed = speed * 2;
        }
        if (Input.GetKeyUp("g"))
        {
            speed = speed / 2;
        }

        if (Input.GetKeyDown("h"))
        {
            Instantiate(fire, transform.position, Quaternion.identity);
        }

        if (horizontalkey > 0 && (NotDiagonal == 0 || NotDiagonal == 1))
        {
            xspeed = speed;
           // NotDiagonal = 1;
        }
        if (horizontalkey < 0 && (NotDiagonal == 0 || NotDiagonal == 2))
        {
            xspeed = -speed;
            //NotDiagonal = 2;
        }
        if (verticalkey > 0 && (NotDiagonal == 0 || NotDiagonal == 3))
        {
            zspeed = speed;
           // NotDiagonal = 3;
        }
        if (verticalkey < 0 && (NotDiagonal == 0 || NotDiagonal == 4))
        {
            zspeed = -speed;
           // NotDiagonal = 4;
        }
        //if(xspeed ==0 && zspeed == 0)
        //{
        //    NotDiagonal = 0;
        //}



        rb.velocity = new Vector3(xspeed, 0,zspeed);
        
    }
}

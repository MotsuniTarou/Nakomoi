using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int speed = 3;
    private Animator animator;
    private Vector3 playerPos;     //プレイヤーのポジション
    private float x, xs = 0;                //x方向にインプットする値
    private float z, zs = 0;                //z方向にインプットする値
    private Rigidbody rb = null;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPos = GetComponent<Transform>().position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 diff = transform.position - playerPos;
        if (!((diff.x > 0.0001 || diff.x < -0.0001) && (diff.z > 0.0001 || diff.z < -0.001)))  //斜め移動時に角度が変わらないようにする
        {

            if (diff.magnitude > 0.001f)
            {
                transform.rotation = Quaternion.LookRotation(diff);
            }
            if (x > 0) xs = 1;
            else if (x < 0) xs = -1;
            else xs = 0;

            if (z > 0) zs = 1;
            else if (z < 0) zs = -1;
            else zs = 0;

        }

        if(xs != 0 || zs != 0)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
        rb.velocity = new Vector3(xs * speed, 0, zs * speed);
        //Debug.Log("xのやつ:" + xs);
        //Debug.Log("sのやつ:" + speed);
        playerPos = transform.position;
        /*if (Input.GetKey("up"))
        {
            transform.position += transform.forward * 0.05f;
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 10, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -10, 0);
        }*/
    }
}


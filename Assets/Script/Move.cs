using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
     public GameObject Cube2;
    public GameObject Cube3;
    public float speed = 10;


    private Rigidbody rb;
    private bool isClick = false;
    private Vector3 curPos2;
    private Vector3 curPos3;
    private float speedINeed;
    private float speedCube2;
    private float speedCube3;

    // Start is called before the first frame update
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        curPos2 = Cube2.transform.position - this.transform.position;
        speedINeed = curPos2.x;
    }

    private void MoveCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            if(hit.collider.name == "Cube2"){
                rb.velocity = curPos2 * speedCube2*speed;
            }
            if(hit.collider.name == "Cube3"){
                rb.velocity = curPos3 * speedCube3*speed;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButton(0)){
            isClick = true;
        } else{
            isClick = false;
            curPos2 = Cube2.transform.position - this.transform.position;
            curPos3 = Cube3.transform.position - this.transform.position;

            speedCube2 = Math.Abs(speedINeed / curPos2.x);
            speedCube3 = Math.Abs(speedINeed / curPos3.x);
        }
    }

    private void FixedUpdate()
    {
        if(isClick == true){
            MoveCube();
        }else{
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}

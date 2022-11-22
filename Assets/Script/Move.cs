using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    
    public float speed = 10;


    private Rigidbody rb;
    private bool isClick = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        // curPos2 = Cube2.transform.position - this.transform.position;
        // speedINeed = curPos2.x;
    }

    private void MoveCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Cube"))
            {
                Vector3 direction = hit.collider.gameObject.transform.position - gameObject.transform.position;
                rb.velocity = direction.normalized * speed;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButton(0)){
            isClick = true;
        } else
        {
            isClick = false ;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Camera mainCamera;
    private Rigidbody rigidBody;
    private bool isClicked;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isClicked = true;
        }
        else
        {
            isClicked = false;
        }
    }

    void FixedUpdate()
    {
        if (isClicked)
        {
            moveCube();
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
        }
    }

    private void moveCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Cube"))
            {
                Vector3 direction = hit.collider.gameObject.transform.position - gameObject.transform.position;
                rigidBody.velocity = direction.normalized * speed;
            }
        }
    }
}

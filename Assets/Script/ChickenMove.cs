using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMove : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5.0f;
    float jampForce = 400.0f;
    Vector3 playerPos;

    bool Ground = true;
    int key = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputKey();
        Move();
    }

    void GetInputKey()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime*speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime*speed;

        if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            key = 1;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
            key = -1;
        }
    }

    void Move()
    {
        if (Ground)
        {
            if (Input.GetButton("Jamp"))
            {
                rb.AddForce(transform.up * jampForce);
                Ground = false;
            }
        }

        rb.MovePosition(transform.position + new Vector3(Input.GetAxisRaw("Horizon") * Time.deltaTime * speed, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed));
        Vector3 direction = transform.position - playerPos;

        if (direction.magnitude >= 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, direction.z));

        }
        else
        {
            key = 0;
        }

        playerPos = transform.localScale;
    }
        void OntriggerEnter(Collider col)
        {
            if(col.gameObject.tag=="Ground")
            {
                if (!Ground)
                    Ground = true;
            }
        }
}

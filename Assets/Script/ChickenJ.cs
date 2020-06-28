using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenJ : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = 5;
            }
        }
        moveDirection.y -= 10 * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

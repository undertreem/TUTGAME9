using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 moveX = new Vector3(2.0f, 0.0f, 0.0f);

    public float speed = 10.0f;
    Vector3 target;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        target = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (transform.position - target).sqrMagnitude;
        if (distance <= 0.002f)
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            TargetPosition();
        }
      //  move();
    }

    void TargetPosition()
    {

        if (Input.GetKey(KeyCode.D))
        {
            target = transform.position + moveX;
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            target = transform.position - moveX;
            return;
        }

    }

/*    private void move()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
*/
    
}

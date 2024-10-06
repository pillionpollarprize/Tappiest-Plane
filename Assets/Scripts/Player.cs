using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 100;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent can get the component attached to the same GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(rb.velocity.y < 0)
            {
                //impulse is a force that is applied instantly, like throwing a ball
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }        
        }
        //animations
        if (rb.velocity.y > 0)
        {
            //quaternion - rotation in 3D space
            //euler - transforms the rotation into a Vector3
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astro : MonoBehaviour
{

    //private Rigidbody2D rigidbody2D;
    public float moveSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
       // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
       // transform.position += movement * Time.deltaTime * moveSpeed;

        /**
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }**/
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 5f), ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, 5, 5f), ForceMode2D.Impulse);

        }
    }

    
}

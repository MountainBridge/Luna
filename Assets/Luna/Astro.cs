using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astro : MonoBehaviour
{

    //private Rigidbody2D rigidbody2D;
    public float moveSpeed = 3f;
    public float jumpHeight = 5f;
    public float startTime;
    public float jumpIncrement = 0f;
    public float incrementDelta = 0.01f;
    public float maxJumpHeight = 7f;
    public SpriteRenderer spriteRenderer;
    public Sprite flyingAstroSprite;
    public Sprite idleAstroSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        PowerJump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        /**
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }**/
    }

    void PowerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            startTime = Time.time;
        } 
        if (Input.GetButton("Jump"))
        {
            jumpIncrement = (Time.time - startTime)*10f;
        }
        if (Input.GetButtonUp("Jump"))
        {
            if(jumpIncrement > maxJumpHeight)
            {
                jumpIncrement = maxJumpHeight;
            }
            spriteRenderer.sprite = flyingAstroSprite;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, jumpHeight + jumpIncrement, 5f), ForceMode2D.Impulse);
            jumpIncrement = 0f;

        }
    }

    // called when the astro hits an obstacle
    void OnCollisionEnter2D(Collision2D col)
    {
        spriteRenderer.sprite = idleAstroSprite;

    }


}

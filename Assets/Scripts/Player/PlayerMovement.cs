using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float Jumpspeed = 5f;
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] 
    private bool grounded;

    float horizontalInput;
   
    private void Awake()
    {
        // Grab reference from Rigidbody and Animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
        
    
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        anim.SetFloat("Run", horizontalInput);



        // for moving player horizontaly
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalInput * speed , body.velocity.y);

        // Flip Player when moving Left Right
        if(HorizontalInput > 0.01f)
                transform.localScale = Vector3.one;
        else if (HorizontalInput < -0.01f)
                transform.localScale = new Vector3(-1,1,1);

        // for jumping
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            jump();
        //  calling function

        // for animation
         anim.SetBool("run",HorizontalInput !=0);
        anim.SetBool("grounded", grounded);
    }


    private void jump()                                     // making function for jump
    {
        body.velocity = new Vector2(body.velocity.x, Jumpspeed);
        anim.SetTrigger("Jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)            // for player is grounded or not
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            Debug.Log(collision.gameObject.name);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("Token"))
        {
            Destroy(other.gameObject);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIpatrol : MonoBehaviour
{
    public float walkSpeed;

    [HideInInspector]
    public bool mustPatrol;
    public bool mustTurn;

    public Rigidbody2D Rb;
    public Transform GroundCheckPos;
    public LayerMask GroundLayer;
    public Collider2D bodyCollider;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(GroundCheckPos.position, 0.1f, GroundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn || bodyCollider.IsTouchingLayers(GroundLayer))
        {
            Flip();
        }

        Rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, Rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}

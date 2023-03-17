using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    private Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyHeadCheck")
        {
            Destroy(transform.parent.gameObject);
            anim.SetTrigger("dead");
        }    
    }
}

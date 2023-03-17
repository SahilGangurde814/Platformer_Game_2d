using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private bool respawn;
    [SerializeField] private AudioSource Hurt;
    [SerializeField] private AudioSource Dead;

    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            Hurt.Play();
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("dead");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                Dead.Play();
               
            }
            
        }
        Invoke("Respawn", 2f);


    }

    void Respawn()
    {

        if (currentHealth <= 0)
        {
            transform.position = new Vector2(-5.67f, 0.04f);
            currentHealth = startingHealth;
            anim.SetTrigger("respawn");
            GetComponent<PlayerMovement>().enabled = true;
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag=="border")
        {
            TakeDamage(3);
        }
            
    }
    private void Update()
    {
        if(currentHealth==startingHealth)
        {
            respawn = false;
            
        }

        anim.SetBool("idle", respawn);

    }
}

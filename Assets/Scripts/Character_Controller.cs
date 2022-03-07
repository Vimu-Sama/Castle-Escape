using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem ;

public class Character_Controller : MonoBehaviour
{

    float h;
    [SerializeField] float  run_speed= 0f ;
    [SerializeField] float jump_speed = 0f;
    Rigidbody2D rb;
    Vector2 v;
    bool jump;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        run_animation();
        Run();
    }

    void OnMove(InputValue input)
    {
        v = input.Get<Vector2>();
    }

    void OnJump(InputValue input)
    {
        if(input.isPressed)
        {
            rb.velocity += new Vector2(0f, jump_speed* Time.deltaTime);
            
        }
    }
    void Run()
    {
        if (v.x < 0)
        {
            transform.localScale = new Vector2((-1) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (v.x > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        rb.velocity =new Vector2(v.x * run_speed * Time.deltaTime, rb.velocity.y) ;
    }

    void run_animation()
    {
        if(v.x!=0)
            animator.SetBool("run", true);
        else
            animator.SetBool("run", false);
    }
}

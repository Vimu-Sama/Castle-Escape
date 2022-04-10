using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movespeed= 1f ;
    BoxCollider2D box_collider;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box_collider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(movespeed * Time.deltaTime, 0f);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.layer == 8)
        {
            movespeed *= (-1);
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
        }
        
    }

}

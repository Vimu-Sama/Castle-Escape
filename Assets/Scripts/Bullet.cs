using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D my_rigidbody;
    [SerializeField] float bullet_speed= 20f;
    Character_Controller player;
    float calculated_speed;

    void Start()
    {
        my_rigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Character_Controller>();
        calculated_speed = bullet_speed * player.transform.localScale.x;
    }

    void Update()
    {
        my_rigidbody.velocity = new Vector2(calculated_speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}

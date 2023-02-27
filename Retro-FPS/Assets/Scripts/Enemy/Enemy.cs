using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;

    public float enemy_speed = 5.0f;
    public int max_hp = 60;

    private int current_hp = 1;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        current_hp = max_hp;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        var destination = player.transform.position;
        var direction = destination - transform.position;
        direction.Normalize();

        rb.velocity = direction * Time.deltaTime * enemy_speed;
    }
    public void TakeDamage (int taken)
    {
        current_hp -= taken;
        if(current_hp < 0) { current_hp = 0; }
    }
    public void HandleHealth()
    {
        if(current_hp == 0)
        {
            Destroy(this);
        }
    }
}

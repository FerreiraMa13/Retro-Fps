using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainScript : MonoBehaviour
{
    private Inventory inventory;
    private PlayerMoveController moveController;

    private int display_hp = 100;

    public int max_hp = 100;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        moveController = GetComponent<PlayerMoveController>();
        display_hp = max_hp;
    }
    public void TakeDamage(int damage)
    {
        display_hp -= damage;
        if(display_hp < 0){display_hp = 0;}
    }
    public void Heal(int heal)
    {
        display_hp += heal;
        if(display_hp >max_hp){display_hp = max_hp;}
    }

}

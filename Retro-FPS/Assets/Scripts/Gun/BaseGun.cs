using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    SHOTGUN = 0,
    UNKNOWN = -1
}
public class BaseGun : MonoBehaviour
{
    private BaseGunAnimator animator;
    private int clip = 0;
    private float fire_timer = 0.0f;
    private float reload_timer = 0.0f;
    private int damage = 5;

    public int ammoCount = 1;
    public float firing_delay = 0.5f;
    public float reload_time = 0.5f;

    [System.NonSerialized] public GunType gunType = GunType.UNKNOWN;

    protected void Awake()
    {
        animator = GetComponent<BaseGunAnimator>();
    }
    protected void Update()
    {
        if(fire_timer > 0)
        {
            fire_timer -= Time.deltaTime;
        }
        if(reload_timer > 0)
        {
            reload_timer -= Time.deltaTime;
        }
    }
    public virtual void Fire()
    {
        if(fire_timer <= 0 && reload_timer <= 0 && clip > 0)
        {
            clip--;
            fire_timer = firing_delay;
            animator.SetAmmo(clip);
            animator.TriggerAttack();
        }
    }
    public virtual void Reload()
    {
        if(reload_timer <= 0 && clip != ammoCount)
        {
            clip = ammoCount;
            reload_timer = reload_time;
            animator.SetAmmo(clip);
        }
    }
    public virtual void PickUp()
    {
        animator.TriggerPick();
    }
    public virtual void TopUpClip()
    {
        clip = ammoCount;
    }
    public int GetDamage()
    {
        return damage;
    }
}


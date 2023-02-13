using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunAnimator : MonoBehaviour
{
    public Animator anim;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void SetAmmo(int value)
    {
    }
    public virtual void TriggerAttack()
    {
    }
    public virtual void TriggerPick()
    {

    }
}

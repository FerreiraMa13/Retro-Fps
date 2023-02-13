using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAnimator : BaseGunAnimator
{
    public override void SetAmmo(int value)
    {
        anim?.SetInteger(ShotgunHash.ammoInt, value);
    }
    public override void TriggerAttack()
    {
        anim?.SetTrigger(ShotgunHash.firingTrigger);
    }
    public override void TriggerPick()
    {
        anim?.SetTrigger(ShotgunHash.pickTrigger);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHashManager: MonoBehaviour
{
    private void Awake()
    {
        ShotgunHash.firingTrigger = Animator.StringToHash("db_Fire");
        ShotgunHash.pickTrigger = Animator.StringToHash("db_Pick");
        ShotgunHash.ammoInt = Animator.StringToHash("db_Ammo");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickUpType
{
    NONE = -1,
    HEALTH = 0,
    KEY_CARD = 1,
    WEAPON = 2
}
public class PickUp : MonoBehaviour
{
    public int pickup_id = 0;
    private PickUpType pick_up_type = PickUpType.NONE;

    public void ApplyEffect()
    {


    }

    public int GetID()
    {
        return pickup_id;
    }
    public PickUpType GetPickUpType()
    {
        return pick_up_type;
    }
}

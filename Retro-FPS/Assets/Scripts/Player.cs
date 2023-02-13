using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<BaseGun> guns;
    private BaseGun current_gun;
    private RetroFPS inputActions;

    Vector2 movement = Vector2.zero;

    private void Awake()
    {
        inputActions = new RetroFPS();
        foreach(var gun in GetComponentsInChildren<BaseGun>())
        {
            guns.Add(gun);
            if (gun.gunType == GunType.SHOTGUN)
            {
                current_gun = gun;
            }
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();
    }
    public void OnFire(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            current_gun.Fire();
        }
    }
    public void OnReload(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            current_gun.Reload();
        }    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<BaseGun> guns = new();
    private List<PickUp> items_inventory = new();
    private Dictionary<GunType, int> ammo_reserve = new();
    public BaseGun current_gun;
    private int gun_index = 0;
    private void Awake()
    {
        foreach (var gun in GetComponentsInChildren<BaseGun>())
        {
            if(!guns.Contains(gun))
            {
                guns.Add(gun);
            }
        }
        current_gun = guns[0];
    }

    public bool isInInventory(GunType gun_type)
    {
        for(int i =0; i < guns.Count; i++)
        {
            if(guns[i].gunType == gun_type)
            {
                return true;
            }
        }
        return false;
    }
    public bool isInInventory(PickUpType pickup, int id)
    {
        for (int i = 0; i < items_inventory.Count; i++)
        {
            if (items_inventory[i].GetPickUpType() == pickup && items_inventory[i].GetID() == id)
            {
                return true;
            }
        }
        return false;
    }
    public BaseGun GetGun(int index)
    {
        return guns[index];
    }
    public bool AddGun(BaseGun gun)
    {
        if(guns.Contains(gun))
        {
            return false;
        }
        else
        {
            guns.Add(gun);
            return true;
        }
    }
    public bool AddItem(PickUp pickUp)
    {
        if (items_inventory.Contains(pickUp)){return false;}
        else
        {
            items_inventory.Add(pickUp);
            return true;
        }
    }
    public  void CycleWeapon(int mod)
    {
        gun_index += mod;
        if(gun_index < 0) { gun_index = guns.Count; }
        if(gun_index > guns.Count) { gun_index = 0; }
        current_gun = guns[gun_index];
    }
    public void ReloadWeapon()
    {
        GunType ammo_type = current_gun.gunType;
        ammo_reserve[ammo_type] -= current_gun.ammoCount;
        
    }
    
}

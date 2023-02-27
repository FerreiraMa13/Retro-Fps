using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    Transform player;
    Vector3 direction;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        direction = player.rotation.eulerAngles;


        transform.rotation = Quaternion.Euler(direction);
    }
}

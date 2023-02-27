using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody2D rb;
    private RetroFPS inputActions;
    private Transform cam_transform;
    private Inventory inventory;

    private Vector2 movement = Vector2.zero;
    private Vector2 rotate = Vector2.zero;
    private float xRotation = 0;

    public int enemy_layer;
    public float movement_speed = 1.0f;
    public float rotate_sensitivity = 1.0f;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inputActions = new RetroFPS();
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
        cam_transform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
        var forwardMove = transform.up * movement.y * -1;
        var horizontalMove = transform.right * movement.x;
        rb.velocity = (forwardMove + horizontalMove) * movement_speed * Time.deltaTime;
    }
    private void HandleRotation()
    {
        /*var mouseInput = rotate * rotate_sensitivity * Time.deltaTime * -1;
        var newRotation = transform.rotation;
        newRotation.z = transform.rotation.z - mouseInput.x;
        transform.rotation = newRotation;*/
        var mouseInput = rotate * rotate_sensitivity * Time.deltaTime;
        xRotation += mouseInput.x;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, xRotation);

    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();
    }
    public void OnFire(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            /*current_gun.Fire();*/
            
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.layer == enemy_layer)
                {
                    var enemy = hit.transform.parent.gameObject.GetComponent<Enemy>();
                    enemy.TakeDamage(inventory.current_gun.GetDamage());
                }
            }

        }
    }
    public void OnReload(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            /*current_gun.Reload();*/
        }    
    }
    public void OnLook(InputAction.CallbackContext ctx)
    {
        rotate = ctx.ReadValue<Vector2>();
    }
}

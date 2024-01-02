using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public GameObject projectile;

    public float speed = 0.2f;


    PlayerInputActions PlayerInput;

    private void Start()
    {
        PlayerInput = new PlayerInputActions();
        PlayerInput.Player.Enable();
        PlayerInput.Player.Fire.performed += Fire;

    }

    public void Fire(InputAction.CallbackContext context)
    {
                        
        GameObject g = Instantiate(projectile, transform.position, transform.rotation);
        Destroy(g, 5);


    }

    private void FixedUpdate()
    {

        Vector2 direction = PlayerInput.Player.Movement.ReadValue<Vector2>();

        direction *= speed;
        
        transform.Translate(direction);

    }


}

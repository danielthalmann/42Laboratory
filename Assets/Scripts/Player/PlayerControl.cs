using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public GameObject projectile;

    public float speed = 0.2f;
    public float interval = 1000.0f;

    private float elapse = 0;

    PlayerInputActions PlayerInput;

    private void Start()
    {
        PlayerInput = new PlayerInputActions();
        PlayerInput.Player.Enable();
        //PlayerInput.Player.Fire.performed += Fire;


    }
    /*
    public void Fire(InputAction.CallbackContext context)
    {
                        
        GameObject g = Instantiate(projectile, transform.position, transform.rotation);
        Destroy(g, 5);

    }
    */

    private void FixedUpdate()
    {

        Vector2 direction = PlayerInput.Player.Movement.ReadValue<Vector2>();
        direction *= speed;
        transform.Translate(direction);

        elapse += Time.deltaTime;

        if (PlayerInput.Player.Fire.IsPressed())
        {
            Debug.Log(elapse);

            if (elapse > interval) {
                elapse = 0;
                GameObject g = Instantiate(projectile, transform.position, transform.rotation);
                Destroy(g, 3);
            }
        }

    }


}

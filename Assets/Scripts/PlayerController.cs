using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerControls coltrols;
    Vector2 movement;


    private void Awake()
    {
        coltrols = new PlayerControls();
        coltrols.PlayerInputGamepad.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        coltrols.PlayerInputGamepad.Movement.canceled += ctx => movement = Vector2.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5f * Time.deltaTime;
        transform.Translate(movementVelocity, Space.World);
    }

    private void OnEnable()
    {
        coltrols.PlayerInputGamepad.Enable();
    }

    private void OnDisable()
    {
        coltrols.PlayerInputGamepad.Disable();
    }
}

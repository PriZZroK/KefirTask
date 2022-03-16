using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : PlayerController
{
   /*private void Awake()
    {
        _playerInputActions.Player.Movement.performed += Movement;
        _playerInputActions.Player.Rotate.performed += Rotate;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        Vector2 _inputVector = context.ReadValue<Vector2>();
        _rigedbody.velocity = new Vector2(_inputVector.x, _inputVector.y) * 10f;
    }

    public void Rotate(InputAction.CallbackContext context) {
        //Debug.Log(context);

    }*/
}

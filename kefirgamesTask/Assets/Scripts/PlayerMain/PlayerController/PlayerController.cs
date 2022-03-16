using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    protected Rigidbody2D _rigedbody;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigedbody = GetComponent<Rigidbody2D>();

        PlayerInputAction _playerInputActions = new PlayerInputAction();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Movement.performed += Movement;
        _playerInputActions.Player.Rotate.performed += Rotate;
        _playerInputActions.Player.Fire.performed += Fire;

    }
    public void Movement(InputAction.CallbackContext context) {

        Vector2 _inputVector = context.ReadValue<Vector2>();
        _rigedbody.AddRelativeForce( new Vector2(_inputVector.x, _inputVector.y) * 1f,ForceMode2D.Impulse); //Vector2.up * 5f; //transform.Translate(Vector2.up * 5f);
        
    }

    public void Rotate(InputAction.CallbackContext context) {

        float a = context.ReadValue<float>();
        Debug.Log(a);
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + a) * 10f);
        //transform.Rotate(transform.rotation.x, transform.rotation.y, a * 5f) ;
        //_rigedbody.MoveRotation( new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z+a, transform.rotation.w) );
        //_rigedbody.MoveRotation(new Quaternion(transform.rotation.x, transform.rotation.y, a, transform.rotation.w));
    }

    public virtual void Fire(InputAction.CallbackContext context) { }
}

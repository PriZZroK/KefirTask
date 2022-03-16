using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public void Move(float _playerSpeed, Rigidbody2D rb)
    {
        rb.AddRelativeForce( Vector2.up * _playerSpeed * Time.deltaTime, ForceMode2D.Impulse);   
    }
    public void Rotate(float _rotateSpeed, bool right,Transform transform)
    {
        if (right) transform.Rotate(new Vector3(0, 0, -1) * _rotateSpeed * Time.deltaTime); else transform.Rotate(new Vector3(0, 0, 1) * _rotateSpeed * Time.deltaTime);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyControlSystem : MonoBehaviour
{
    public float Health;
    public float Speed;

    public abstract void Move();

}

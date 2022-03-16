using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DamageableObj
{
    void OnTriggerEnter2D(Collider2D coll);

    void TakeDamage(float Damage);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileDamage : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<DamageableObj>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
        else { }
    }
}

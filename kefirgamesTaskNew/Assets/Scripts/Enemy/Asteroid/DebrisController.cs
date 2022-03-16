using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisController : EnemyControlSystem, DamageableObj
{
    MainGUI GUI;
    void Start()
    {
        Destroy(this.gameObject, 5f);
        GUI = GameObject.FindGameObjectWithTag("GUI").GetComponent<MainGUI>();
    }
    public override void Move() { }
    

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerController>()) GUI.PlayerDie();
    }

    public void TakeDamage(float Damage)
    {
        this.Health -= Damage;
        if (this.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

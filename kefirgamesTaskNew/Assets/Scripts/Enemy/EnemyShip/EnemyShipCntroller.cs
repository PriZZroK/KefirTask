using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipCntroller : EnemyControlSystem, DamageableObj
{
    Rigidbody2D rb;
    GameObject _player;
    MainGUI GUI;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        GUI = GameObject.FindGameObjectWithTag("GUI").GetComponent<MainGUI>();
    }
    void Update()
    {
        Move();
    }
    public override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, Speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerController>()) GUI.PlayerDie();
    }

    public void TakeDamage(float Damage)
    {
        this.Health -= Damage;
        if (this.Health <= 0)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AddScore(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EnemyShipReward);
            Destroy(this.gameObject);
        }
    }
}

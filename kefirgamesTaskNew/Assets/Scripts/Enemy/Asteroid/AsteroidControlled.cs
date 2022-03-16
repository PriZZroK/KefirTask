using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControlled : EnemyControlSystem, DamageableObj
{
    public GameObject DebrisPref;
    public List<Transform> DebrisSpawnPoints;
    public float DebrisSpeed;
    Rigidbody2D rb;
    MainGUI GUI;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Move();
        Destroy(this.gameObject, 25f);
        GUI = GameObject.FindGameObjectWithTag("GUI").GetComponent<MainGUI>();
    }

    public override void Move()
    {
        rb.AddForce(transform.TransformDirection(Vector2.up) * Speed, ForceMode2D.Force);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerController>()) GUI.PlayerDie();
    }

    public void TakeDamage(float Damage)
    {
        this.Health -= Damage;
        if(this.Health <= 0)
        {
            DestroyObj();
        }
    }

    void DestroyObj()
    {
        for(int i=0; i < DebrisSpawnPoints.Count; i++)
        {
            GameObject _deb = Instantiate(DebrisPref, DebrisSpawnPoints[i].position, DebrisSpawnPoints[i].rotation);
            _deb.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * DebrisSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AddScore(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AsteroidReward);
        Destroy(this.gameObject);
    }
}

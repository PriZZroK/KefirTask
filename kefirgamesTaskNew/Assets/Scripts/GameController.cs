using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<Transform> AsteroidSpawnPoints;
    [SerializeField] private float AseroidSpawnInterval;
    [SerializeField] private GameObject AsteroidPref;
    [SerializeField] private List<Transform> EnemyShipSpawnPoints;
    [SerializeField] private float EnemyShipSpawnInterval;
    [SerializeField] private GameObject EnemyShipPref;

    [HideInInspector] public int Score;
    public int AsteroidReward;
    public int EnemyShipReward;



    private void Start()
    {
        StartCoroutines();
    }

    public void AddScore(int reward)
    {
        Score += reward;
    }
    void StartCoroutines()
    {
        StartCoroutine(AsteroidSpawn());
        StartCoroutine(EnemyShipSpawn());
    }

    IEnumerator AsteroidSpawn()
    {
        int i = Random.Range(0, AsteroidSpawnPoints.Count);
        Instantiate(AsteroidPref, AsteroidSpawnPoints[i].position, AsteroidSpawnPoints[i].rotation);
        yield return new WaitForSeconds(AseroidSpawnInterval);
        StartCoroutine(AsteroidSpawn());
    }

    IEnumerator EnemyShipSpawn()
    {
        int i = Random.Range(0, EnemyShipSpawnPoints.Count);
        Instantiate(EnemyShipPref, EnemyShipSpawnPoints[i].position, EnemyShipSpawnPoints[i].rotation);
        yield return new WaitForSeconds(EnemyShipSpawnInterval);
        StartCoroutine(EnemyShipSpawn());
    }
}

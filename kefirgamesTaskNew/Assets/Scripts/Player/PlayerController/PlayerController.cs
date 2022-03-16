using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovementController _playerMovementController;
    PlayerFireController _playerFireController;
    Rigidbody2D rb;


    [SerializeField] private float PlayerSpeed;
    [SerializeField] private float RotateSpeed;

    [SerializeField] private GameObject PrjPref;
    [SerializeField] private float PrjSpeed;
    [SerializeField] private float PrjDamage;
    [SerializeField] private Transform PrjSpawnPoint;

    [SerializeField] private float BeamDamage;
    [SerializeField] private float BeamReload;
    [HideInInspector] public float localReload;
    [SerializeField] private float BeamTime;
     private float localbeamTime;
    [SerializeField] private LineRenderer Beam;
    [SerializeField] private Transform BeamSpawnPoint;
    [SerializeField] private Transform BeamEndPoint;
    bool StartTimer;


    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
        _playerFireController = GetComponent<PlayerFireController>();
        rb = GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        StartTimer = true;
        localReload = BeamReload;
    }
    private void Update()
    {
        Movement();
        Rotate();
        Fire();
        Timer();
        Teleport();
    }
    private void Teleport()
    {
        float xBorder = 18;
        float yBorder = 11;

        if (transform.position.x > xBorder) { 
            transform.position = new Vector2(-xBorder, -transform.position.y); 
        }
        if (transform.position.x < -xBorder)
        {
            transform.position = new Vector2(xBorder, -transform.position.y);
        }

        if (transform.position.y > yBorder)
        {
            transform.position = new Vector2(transform.position.x, -yBorder);
        }
        if (transform.position.y < -yBorder)
        {
            transform.position = new Vector2(transform.position.x, yBorder);
        }
    }
    void Timer()
    {
        if (StartTimer) localReload -= Time.deltaTime; localbeamTime -= Time.deltaTime;
        if (localReload <= 0) localReload = 0;
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            bool up = true;
            _playerMovementController.Move(PlayerSpeed, rb);
        }
    }
    void Rotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            bool right = true;
            _playerMovementController.Rotate(RotateSpeed, right, transform);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            bool right = false;
            _playerMovementController.Rotate(RotateSpeed, right, transform);
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerFireController.FirePrj(PrjSpeed, PrjSpawnPoint, PrjPref, PrjDamage);
        }
        if (Input.GetMouseButton(1))
        {
            if (localReload <= 0){
                localbeamTime = BeamTime;
                StartTimer = true;
                localReload = BeamReload;
            }
            _playerFireController.FireBeam(Beam, BeamSpawnPoint, BeamEndPoint, localbeamTime, BeamDamage);
        }
        else Beam.enabled = false;
    }
}

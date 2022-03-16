using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGUI : MonoBehaviour
{
    PlayerController _playerController;
    GameController _gameController;
    GameObject _player;

    [SerializeField] private GameObject RestartButton;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text BeamReloadText;
    [SerializeField] private Text PlayerCoordsText;
    [SerializeField] private Text PlayerSpeedText;
    [SerializeField] private Text QuaternionText;
    [SerializeField] private Text EndScoreText;

    private void Start()
    {
        Time.timeScale = 1;
        RestartButton.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        BeamReload();
        PlayerSpeed();
        PlayerCoords();
        Score();
        Quaternion();
    }
    private void BeamReload()
    {
        BeamReloadText.text = _playerController.localReload.ToString();
    }
    private void PlayerSpeed()
    {
        PlayerSpeedText.text = _player.GetComponent<Rigidbody2D>().velocity.magnitude.ToString();
    }
    private void PlayerCoords()
    {
        PlayerCoordsText.text = _player.GetComponent<Transform>().position.ToString();
    }
    private void Score()
    {
        ScoreText.text = _gameController.Score.ToString();
    }
    private void Quaternion()
    {
        QuaternionText.text = _player.GetComponent<Transform>().rotation.z.ToString();
    }

    private void GameEnd()
    {
        EndScoreText.text = ScoreText.text;

        BeamReloadText.text = "";
        PlayerSpeedText.text = "";
        PlayerCoordsText.text = "";
        ScoreText.text = "";
        QuaternionText.text = "";

    }
    public void PlayerDie()
    {
        GameEnd();
        RestartButton.SetActive(true);
        Time.timeScale = 0;

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

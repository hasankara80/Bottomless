using System;
using DG.Tweening;
using UnityEngine;

public class SettingsButtonManager : MonoBehaviour
{
    public static SettingsButtonManager Instance { get; private set; }
    [SerializeField] private Transform settingsCanvas;
    [SerializeField] private Transform audioCanvas;
    [SerializeField] private Transform player;
    private GameStartManager _gameStartManager;
    private PlayerMovement _playerMovement;
    private int _clickCount;
    private Camera _cam;
    public Transform loseCanvas;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _gameStartManager = GameStartManager.Instance;
        _playerMovement = PlayerMovement.Instance;
        _clickCount = 0;
        _cam = Camera.main;
    }

    public void PressSettingsButton()
    {
        settingsCanvas.DOScale(1, 0.25f);
        _gameStartManager.isCanStartGame = false;
    }

    public void PressSilenceButton()
    {
        audioCanvas.localScale = Vector3.zero;
        _clickCount++;
        if (_clickCount == 2)
        {
            audioCanvas.localScale = Vector3.one;
            _clickCount = 0;
        }
    }

    public void PressRestartButtonOnSettings()
    {
        _gameStartManager.isCanStartGame = false;
        EventManager.Instance.MoveIntro();
        _playerMovement.healthValue = 5;
        _playerMovement.starValue = 0;
        _playerMovement.arrowCount = 0;
        _cam.transform.position = new Vector3(player.position.x, _cam.transform.position.y, player.position.z);
        settingsCanvas.transform.DOScale(0, 0.1f);
    }

    public void PressRestartButtonOnLose()
    {
        loseCanvas.transform.DOScale(0, 0.1f);
    }

    public void PressCloseButton()
    {
        settingsCanvas.DOScale(0, 0.25f);
        _gameStartManager.isCanStartGame = true;
    }
}

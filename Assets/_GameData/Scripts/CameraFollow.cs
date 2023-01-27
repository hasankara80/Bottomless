using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameStartManager _gameStartManager;
    private PlayerMovement _playerMovement;
    [SerializeField] private Transform player;

    private void Start()
    {
        _playerMovement = PlayerMovement.Instance;
        _gameStartManager = GameStartManager.Instance;
    }

    private void Update()
    {
        if (!_playerMovement.isStartMovementCompleted)
        {
            transform.DOMoveX(player.position.x, 0.5f);
        }

        if (player.position.z > 0)
        {
            transform.DOMoveZ(player.position.z + 2, 0.5f);
        }
    }
}

using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private bool _isStartMovementCompleted;
    private GameStartManager _gameStartManager;
    
    private void Awake()
    {
        _gameStartManager = GameStartManager.Instance;
    }
    
    private void Start()
    {
        _isStartMovementCompleted = false;
        transform.DOMoveX(0, 2).SetEase(Ease.InCubic).OnComplete(() =>
        {
            _isStartMovementCompleted = true;
        });
    }

    private void Update()
    {
        if (!_isStartMovementCompleted) return;
        if (!_gameStartManager.isCanStartGame) return;
        transform.Translate(Vector3.down * 10 * Time.deltaTime);
    }
}

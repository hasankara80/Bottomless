using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*[SerializeField] private Transform target;
    private float _smoothSpeed;
    private Vector3 _offset;

    private void Start()
    {
        _smoothSpeed = 0.125f;
        _offset = new Vector3(0, 22, 0);
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + _offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothPosition;
    }*/
    
    private bool _isStartMovementCompleted;
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
        transform.Translate(Vector3.down * 2 * Time.deltaTime);
    }
}

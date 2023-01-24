using System;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isStartMovementCompleted;
    private void Start()
    {
        isStartMovementCompleted = false;
        transform.DOMoveX(0, 2).SetEase(Ease.InCubic).OnComplete(() =>
        {
            isStartMovementCompleted = true;
        });
    }

    private void Update()
    {
        if (isStartMovementCompleted)
        {
            transform.Translate(Vector3.up * 2 * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.DOMoveX(transform.position.x - 2, 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.DOMoveX(transform.position.x + 2, 0.5f);
            }
        }
    }
}

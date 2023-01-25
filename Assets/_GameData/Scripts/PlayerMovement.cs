using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool _isStartMovementCompleted;
    private int _arrowCount;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI starText;
    private int _healthValue;
    private int _starValue;
    private HealthBarManager _healthBarManager;

    private void Start()
    {
        _healthValue = 5;
        _starValue = 0;
        _isStartMovementCompleted = false;
        _arrowCount = 0;
        _healthBarManager = HealthBarManager.Instance;
        transform.DOMoveX(3.5f, 1).SetEase(Ease.InCubic).OnComplete(() =>
        {
            transform.DOMove(new Vector3(0, 0, -2), 1).OnComplete(() =>
            {
                _isStartMovementCompleted = true;
            });
        });
    }

    private void Update()
    {
        if (!_isStartMovementCompleted) return;
        transform.Translate(Vector3.up * 10 * Time.deltaTime);

        if (_arrowCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.DOMoveX(-2, 0.5f);
                _arrowCount++;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.DOMoveX(2, 0.5f);
                    _arrowCount--;
            }
        }

        else if (_arrowCount == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.DOMoveX(0, 0.5f);
                _arrowCount--;
            }
        }
        
        else if (_arrowCount == -1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.DOMoveX(0, 0.5f);
                _arrowCount++;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            _healthValue--;
            _healthBarManager.ShowHeart(healthText,_healthValue);
            _healthBarManager.ChangeSlider(_healthValue);
        }

        if (collision.collider.CompareTag("Heart"))
        {
            _healthValue++;
            _healthBarManager.ShowHeart(healthText,_healthValue);
            _healthBarManager.ChangeSlider(_healthValue);
        }

        if (collision.collider.CompareTag("Star"))
        {
            _starValue++;
            starText.text = _starValue.ToString();
            ScaleStar();
        }
    }

    private void ScaleStar()
    {
        starText.transform.DOScale(2f, 0.5f).OnComplete(() =>
        {
            starText.transform.DOScale(1, 0.5f);
        });
    }
}
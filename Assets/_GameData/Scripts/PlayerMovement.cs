using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }
    [HideInInspector] public bool isStartMovementCompleted;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI starText;
    [HideInInspector] public int healthValue;
    [HideInInspector] public int starValue;
    [HideInInspector] public int arrowCount;
    private HealthBarManager _healthBarManager;
    private GameStartManager _gameStartManager;
    private TutorialManager _tutorialManager;
    private SettingsButtonManager _settingsButtonManager;
    [SerializeField] private Transform redEffect;
    [SerializeField] private Transform tapToPlay;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorController walkingAnimatorController;
    [SerializeField] private AnimatorController fallAnimatorController;
    [SerializeField] private AnimatorController jumpAnimatorController;

    // private void OnEnable()
    // {
    //     EventManager.Instance.OnIntroMoved += OnIntroMovedHandler;
    // }
    //
    // private void OnDisable()
    // {
    //     EventManager.Instance.OnIntroMoved -= OnIntroMovedHandler;
    // }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        healthValue = 5;
        starValue = 0;
        isStartMovementCompleted = false;
        arrowCount = 0;
        _healthBarManager = HealthBarManager.Instance;
        _tutorialManager = TutorialManager.Instance;
        _gameStartManager = GameStartManager.Instance;
        _settingsButtonManager = SettingsButtonManager.Instance;
        OnIntroMovedHandler();
        animator.runtimeAnimatorController = walkingAnimatorController;
    }

    private void Update()
    {
        if(!isStartMovementCompleted) return;
        if(!_gameStartManager.isCanStartGame) return;
        transform.Translate(Vector3.down * 10 * Time.deltaTime);
        if (arrowCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.DOMoveX(-2, 0.5f);
                arrowCount++;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.DOMoveX(2, 0.5f);
                    arrowCount--;
            }
        }

        else if (arrowCount == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.DOMoveX(0, 0.5f);
                arrowCount--;
            }
        }
        
        else if (arrowCount == -1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.DOMoveX(0, 0.5f);
                arrowCount++;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            healthValue--;
            _healthBarManager.ShowHeart(healthText,healthValue);
            _healthBarManager.ChangeSlider(healthValue);
            StartCoroutine(ShowRedEffect());
            collision.collider.enabled = false;
            if (healthValue == 0)
            {
                _settingsButtonManager.loseCanvas.DOScale(1, 0.2f);
                _gameStartManager.isCanStartGame = false;
            }
        }

        if (collision.collider.CompareTag("Heart"))
        {
            healthValue++;
            if (healthValue > 4)
            {
                healthValue = 5;
            }
            _healthBarManager.ShowHeart(healthText,healthValue);
            _healthBarManager.ChangeSlider(healthValue);
            collision.collider.gameObject.transform.DOScale(0, 0.2f);
        }

        if (collision.collider.CompareTag("Star"))
        {
            starValue++;
            starText.text = starValue.ToString();
            ScaleStar();
            collision.collider.gameObject.transform.DOScale(0, 0.2f);
            if (starValue == 20)
            {
                _settingsButtonManager.winCanvas.DOScale(1, 0.2f);
            }
        }

        if (collision.collider.CompareTag("Tutorial"))
        {
            _gameStartManager.isCanStartGame = false;
            _tutorialManager.tutorialText.DOScale(1, 0.25f);
            collision.collider.enabled = false;
        }
    }

    private void ScaleStar()
    {
        starText.transform.DOScale(2f, 0.5f).OnComplete(() =>
        {
            starText.transform.DOScale(1, 0.5f);
        });
    }

    private void OnIntroMovedHandler()
    {
        transform.DOMoveX(3.5f, 1).SetEase(Ease.InCubic).OnComplete(() =>
        {
            animator.runtimeAnimatorController = jumpAnimatorController;
            transform.DOMove(new Vector3(0, 1.3f, -2), 1).OnComplete(() =>
            {
                transform.DOLocalRotate(new Vector3(-90, 0, 0), 1).OnComplete(() =>
                {
                    tapToPlay.localScale = Vector3.one;
                });
                animator.runtimeAnimatorController = fallAnimatorController;
                isStartMovementCompleted = true;
            });
        });
    }
    
    IEnumerator ShowRedEffect()
    {
        redEffect.localScale = Vector3.one;
        yield return new WaitForSeconds(.5f);
        redEffect.localScale = Vector3.zero;
    }
}
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public static GameStartManager Instance { get; private set; }
    [HideInInspector] public bool isCanStartGame = false;
    [SerializeField] private Transform tapToPlay;

    private void Awake()
    {
        Instance = this;
    }
    
    public void StartGame()
    {
        isCanStartGame = true;
        tapToPlay.transform.DOScale(0, 0.5f);
    }
}

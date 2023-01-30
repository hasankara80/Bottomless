using System;
using UnityEditor;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    
    public event Action OnIntroMoved;
    public void MoveIntro() => OnIntroMoved?.Invoke();

    public event Action OnGameStarted;
    public void StartGame() => OnGameStarted?.Invoke();
}

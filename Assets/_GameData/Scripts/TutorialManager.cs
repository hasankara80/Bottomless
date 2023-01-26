using DG.Tweening;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }
    public Transform tutorialText;

    private void Awake()
    {
        Instance = this;
    }

    public void PressTutorialButton()
    {
        GameStartManager.Instance.isCanStartGame = true;
        tutorialText.DOScale(0, 0.5f);
    }
}

using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public static HealthBarManager Instance { get; private set; }
    [SerializeField] private Slider slider;
    private Tween _sliderLerp;
    [SerializeField] private Transform heartText;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeSlider(int healthValue)
    {
        var targetValue =  0.2f * healthValue;
        var currentValue = slider.value;
        _sliderLerp.Kill();
        _sliderLerp = DOTween.To(() => currentValue , x => currentValue = x, targetValue, 0.5f).OnUpdate(() =>
        {
            slider.value = currentValue;
        });
    }

    public void ShowHeart(TextMeshProUGUI text, int healthValue)
    {
        text.text = healthValue.ToString();
        heartText.DOScale(1, 0.5f).OnComplete(() =>
        {
            heartText.DOScale(1.3f, 0.25f).OnComplete(() =>
            {
                heartText.DOScale(1, 0.25f).OnComplete(() =>
                {
                    StartCoroutine(DisappearHeart());
                });
            });
        });
    }

    IEnumerator DisappearHeart()
    {
        yield return new WaitForSeconds(.5f);
        heartText.DOScale(0, 0.25f);
    }
}

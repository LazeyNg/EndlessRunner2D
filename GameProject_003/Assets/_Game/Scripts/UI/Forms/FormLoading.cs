using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FormLoading : MonoBehaviour
{
    [Header("Loading")]
    public float loadDuration;
    public Image fillImage;
    public AnimationCurve loadingCurve;

    private void Start()
    {
        DOVirtual.DelayedCall(2f, () =>
        {
            // SoundManager.instance.PlaySoundBackground(BACKGROUND_TYPE.GAME);
            DOVirtual.Float(0f, 1f, loadDuration, value =>
            {
                fillImage.transform.localScale = new Vector3(value, 1, 0);
            })
            .SetEase(loadingCurve)
            .OnComplete(() =>
            {
                UIManager.instance.ChangeScene(Scene.Home);
            });
        });
    }
}

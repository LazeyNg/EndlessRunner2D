using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("Block Input")]
    public bool isBlockInput = false;
    public float timeBlockInput;
    public GameObject objBlockInput;

    [Header("Form Reference")]
    public FormLoading formLoading;
    public FormHome formHome;
    public FormGame formGame;

    [Header("Fade In/Out")]
    public CanvasGroup fadePanel;
    public float timeFadeOut;
    public float timeFadeIn;

    private void Start()
    {
        //fadePanel.gameObject.SetActive(true);
        //fadePanel.alpha = 1f;

        //DOVirtual.Float(1f, 0f, timeFadeIn, value => { fadePanel.alpha = value; })
        //  .OnComplete(() =>
        //  {
        //      fadePanel.gameObject.SetActive(false);
        //  }).SetEase(Ease.Linear);
    }

    public void ChangeScene(Scene newScene)
    {
        DOTween.KillAll();

        fadePanel.gameObject.SetActive(true);
        fadePanel.alpha = 0f;

        DOVirtual.Float(0f, 1f, timeFadeOut, value => { fadePanel.alpha = value; })
            .OnComplete(() =>
            {
                StartCoroutine(IELoadScene(newScene.ToString()));
            });
    }

    IEnumerator IELoadScene(string sceneName)
    {
        var sceneAsync = SceneManager.LoadSceneAsync(sceneName);
        sceneAsync.allowSceneActivation = false;
        while (!sceneAsync.isDone)
        {
            if (sceneAsync.progress >= 0.9f)
            {
                yield return new WaitForSeconds(.1f);
                sceneAsync.allowSceneActivation = true;
                break;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}

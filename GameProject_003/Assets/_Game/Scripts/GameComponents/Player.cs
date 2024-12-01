using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform thisTf;

    public float laneDistance;
    public float timeChangeLane;

    private int positionOrder = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && positionOrder > -1)
        {
            positionOrder -= 1;

            thisTf.DOMoveX(positionOrder * laneDistance, timeChangeLane).SetEase(Ease.Linear);
            thisTf.DORotate(new Vector3(0, 0, -positionOrder * 90f), timeChangeLane).SetEase(Ease.Linear);
        }
        else if (Input.GetKeyDown(KeyCode.D) && positionOrder < 1)
        {
            positionOrder += 1;

            thisTf.DOMoveX(positionOrder * laneDistance, timeChangeLane).SetEase(Ease.Linear);
            thisTf.DORotate(new Vector3(0, 0, -positionOrder * 90f), timeChangeLane).SetEase(Ease.Linear);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Lose
            Time.timeScale = 0;
            UIManager.instance.formGame.EndGame();
        }
    }
}

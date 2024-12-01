using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isPlayingGame = false;
    
    public float spawnTime;
    public float obstacleMoveTime;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;

        // DataManager.instance.LoadData();
    }

    public void StartGame()
    {
        isPlayingGame = true;

        StartCoroutine(IESpawnObstacle());
    }

    IEnumerator IESpawnObstacle()
    {
        while (isPlayingGame)
        {
            GameObject obj = PoolManager.instance.RequestObject();
            obj.transform.position = new Vector3(Random.Range(-1, 2) * 1.5f, 6, 0);
            obj.transform.DOMoveY(-5.5f, obstacleMoveTime).SetEase(Ease.Linear).OnComplete(() =>
            {
                UIManager.instance.formGame.AddScore();
                PoolManager.instance.DespawnObject(obj);
            });

            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void IncreaseDifficulties()
    {
        if (spawnTime >= 0.5f) spawnTime *= 0.9f;
        if (obstacleMoveTime >= 1.25) obstacleMoveTime *= 0.9f;
    }
}

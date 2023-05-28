using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

[Serializable]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Entity[] spawnObjects;
    [SerializeField] private Transform area;
    [SerializeField] private float delay;

    private Player Player => GameManager.instance.Player;
    private float time;
    private Coroutine timer;

    private void Start()
    {
        GameManager.instance.OnEnd += EndGame;

        timer = StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (true)
        {
            time += Time.deltaTime;

            if (time > delay)
            {
                Spawn();
                time %= delay;
            }
            yield return null;
        }
    }

    private void Spawn()
    {
        float x = Random.Range(-area.localScale.x / 2, area.localScale.x / 2);
        float z = Random.Range(-area.localScale.z / 2, area.localScale.z / 2);
        Entity spawnObject = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], area.position + new Vector3(x, 0, z), Quaternion.identity);

        spawnObject.Init(Player);
    }

    private void EndGame(TimeSpan timeSpan)
    {
        GameManager.instance.OnEnd -= EndGame;

        StopCoroutine(timer);
    }
}

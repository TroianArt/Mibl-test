using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action<TimeSpan> OnEnd;

    [SerializeField] private Player player;

    private DateTime startTime;

    public Player Player => player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startTime = DateTime.UtcNow;
        player.OnDied += PlayerDied;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        
    }

    private void PlayerDied()
    {
        player.OnDied -= PlayerDied;

        OnEnd?.Invoke(DateTime.UtcNow - startTime);

    }

    private void OnDestroy()
    {
        player.OnDied -= PlayerDied;
    }
}

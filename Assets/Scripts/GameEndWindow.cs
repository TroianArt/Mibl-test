using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text duration;
    [SerializeField] private Button playAgain;

    private void Start()
    {
        gameObject.SetActive(false);
        GameManager.instance.OnEnd += ShowWindow;
        playAgain.onClick.RemoveAllListeners();
        playAgain.onClick.AddListener(GameManager.instance.Restart);
    }

    public void ShowWindow(TimeSpan timeSpan)
    {
        gameObject.SetActive(true);
        duration.text = ((int)timeSpan.TotalSeconds).ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    private bool timerIsActive;
    public float timeLeft = 60.0f; // in seconds
    [SerializeField] private TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsActive)
        {
            timeLeft -= Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(timeLeft);
            timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();

            if (timeLeft <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

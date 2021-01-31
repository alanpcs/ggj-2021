using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float _timer;
    private Text _timerText;

    // Start is called before the first frame update
    void Start()
    {
        _timerText = gameObject.GetComponent<Text>();
        _timer = 91;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        _timerText.text = _timer.ToString("F0");

        if (_timer <= 0.0f)
        {
            // calculate the result
            // load new scene
            // SceneManager.LoadScene("SceneName");
        }
    }
}

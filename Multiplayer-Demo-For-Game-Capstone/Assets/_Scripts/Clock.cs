using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private float _amoutOfTime;
    private bool _startTimer;
    private Text _display;

    public float AmoutOfTime
    {
        get { return _amoutOfTime; }
        set { 
            _amoutOfTime = value;
            if(_amoutOfTime > 0)
            {
                StartTimer = true;
            }
            else
            {
                _startTimer = false;
            }
        }   
    }
    /// <summary>
    /// If counter is finished or not
    /// false meaning not counting or timer finish
    /// true meaning its counting down
    /// </summary>
    public bool StartTimer
    {
        get { return _startTimer; }
        set { _startTimer = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _display = GetComponent<Text>();
        _display.text = "0:00";
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            AmoutOfTime -= Time.deltaTime;
            _display.text = FormatTime(AmoutOfTime);
        }
    }
    private string FormatTime(float time)
    {
        int hours = (int)time / 60000;
        int minutes = (int)time / 1000 - 60 * hours;
        int seconds = (int)time - hours * 60000 - 1000 * minutes;
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}

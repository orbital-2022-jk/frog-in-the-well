using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    private static readonly string timer_pref = "Timer";
    private float curr_time;
    public TextMeshProUGUI curr_time_text;

    // Start is called before the first frame update
    void Start()
    {
        // set curr_time to be 0
        curr_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // update curr_time
        curr_time += Time.deltaTime;
        PlayerPrefs.SetFloat(timer_pref, curr_time);
        TimeSpan time_span = TimeSpan.FromSeconds(curr_time);

        // update text
        curr_time_text.text = string.Format("Time: {0:D2}:{1:D2}:{2:D2}", time_span.Hours, time_span.Minutes, time_span.Seconds);
    }
}

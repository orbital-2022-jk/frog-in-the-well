using UnityEngine;
using System;
using TMPro;

public class FinalTime : MonoBehaviour
{
    private static readonly string timer_pref = "Timer";
    private float curr_time;
    public TextMeshProUGUI curr_time_text;

    // Start is called before the first frame update
    void Start()
    {
        // find time taken
        curr_time = PlayerPrefs.GetFloat(timer_pref);
        TimeSpan time_span = TimeSpan.FromSeconds(curr_time);

        // format the text
        curr_time_text.text = string.Format("{0:D2}:{1:D2}:{2:D2}", time_span.Hours, time_span.Minutes, time_span.Seconds);
    }
}

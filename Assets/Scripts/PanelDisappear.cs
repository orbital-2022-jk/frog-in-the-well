using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDisappear : MonoBehaviour
{
    public GameObject panel;
    public float active_duration;

    // Start is called before the first frame update
    void Start()
    {
        // ensure that panel is active at start of scene
        panel.SetActive(true);

        // disappear panel after duration
        Invoke("Disappear", active_duration);
    }

    void Disappear()
    {
        panel.SetActive(false);
    }
}

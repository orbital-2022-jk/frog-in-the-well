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
        panel.SetActive(true);

        Invoke("Disappear", active_duration);
    }

    void Disappear()
    {
        panel.SetActive(false);
    }
}

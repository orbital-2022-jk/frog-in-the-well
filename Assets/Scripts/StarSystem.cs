using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarSystem : MonoBehaviour
{
    public Image[] star_img = new Image[5];
    public Image[] star_empty = new Image[5];
    private bool[] star_active = new bool[5];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("star_" + (i + 1).ToString(), 0);
            star_active[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!star_active[i] && PlayerPrefs.GetInt("star_" + (i + 1).ToString()) == 1)
            {
                star_active[i] = true;
                star_img[i].gameObject.SetActive(true);
                star_empty[i].gameObject.SetActive(false);
            }
        }
    }
}

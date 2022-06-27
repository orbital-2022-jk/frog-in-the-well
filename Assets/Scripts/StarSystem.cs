using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarSystem : MonoBehaviour
{
    private static readonly string star_1 = "star_1";
    private static readonly string star_2 = "star_2";
    private static readonly string star_3 = "star_3";
    private static readonly string star_4 = "star_4";
    private static readonly string star_5 = "star_5";

    public Image star_1_img;
    public Image star_2_img;
    public Image star_3_img;
    public Image star_4_img;
    public Image star_5_img;

    private bool star_1_active = false;
    private bool star_2_active = false;
    private bool star_3_active = false;
    private bool star_4_active = false;
    private bool star_5_active = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(star_1, 0);
        PlayerPrefs.SetInt(star_2, 0);
        PlayerPrefs.SetInt(star_3, 0);
        PlayerPrefs.SetInt(star_4, 0);
        PlayerPrefs.SetInt(star_5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!star_1_active && PlayerPrefs.GetInt(star_1) == 1)
        {
            star_1_active = true;
            star_1_img.gameObject.SetActive(true);
        }
        if (!star_2_active && PlayerPrefs.GetInt(star_2) == 1)
        {
            star_2_active = true;
            star_2_img.gameObject.SetActive(true);
        }
        if (!star_3_active && PlayerPrefs.GetInt(star_3) == 1)
        {
            star_3_active = true;
            star_3_img.gameObject.SetActive(true);
        }
        if (!star_4_active && PlayerPrefs.GetInt(star_4) == 1)
        {
            star_4_active = true;
            star_4_img.gameObject.SetActive(true);
        }
        if (!star_5_active && PlayerPrefs.GetInt(star_5) == 1)
        {
            star_5_active = true;
            star_5_img.gameObject.SetActive(true);
        }
    }
}

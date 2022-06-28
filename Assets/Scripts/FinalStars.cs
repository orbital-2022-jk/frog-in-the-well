using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalStars : MonoBehaviour
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
    public Image star_1_empty;
    public Image star_2_empty;
    public Image star_3_empty;
    public Image star_4_empty;
    public Image star_5_empty;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(star_1) == 1)
        {
            star_1_img.gameObject.SetActive(true);
            star_1_empty.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt(star_2) == 1)
        {
            star_2_img.gameObject.SetActive(true);
            star_2_empty.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt(star_3) == 1)
        {
            star_3_img.gameObject.SetActive(true);
            star_3_empty.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt(star_4) == 1)
        {
            star_4_img.gameObject.SetActive(true);
            star_4_empty.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt(star_5) == 1)
        {
            star_5_img.gameObject.SetActive(true);
            star_5_empty.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

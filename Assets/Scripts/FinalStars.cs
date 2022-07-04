using UnityEngine;
using UnityEngine.UI;

public class FinalStars : MonoBehaviour
{
    public Image[] star_img = new Image[5];
    public Image[] star_empty = new Image[5];

    // Start is called before the first frame update
    void Start()
    {
        // set the appropriate stars to be active
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.GetInt("star_" + (i + 1).ToString()) == 1)
            {
                star_img[i].gameObject.SetActive(true);
                star_empty[i].gameObject.SetActive(false);
            }
        }
    }
}

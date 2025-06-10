using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningController : MonoBehaviour
{
    public GameObject[] slides;
    public float slideDuration = 4f; 

    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        ShowSlide(0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= slideDuration)
        {
            NextSlide();
            timer = 0f;
        }
    }

    void ShowSlide(int index)
    {
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == index);
        }
    }

    void NextSlide()
    {
        currentIndex++;
        if (currentIndex >= slides.Length)
        {
            SceneManager.LoadScene("Start Menu");
        }
        else
        {
            ShowSlide(currentIndex);
        }
    }
}

using UnityEngine;  
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject HowToPlay;
    [SerializeField]
    private GameObject Credits;

    void Start()
    {
        HowToPlay.SetActive(false);
        Credits.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        Credits.SetActive(false);
        if (HowToPlay.activeSelf)
        {
            HowToPlay.SetActive(false);
        }
        else
        {
            HowToPlay.SetActive(true);
        }
    }

    public void ShowCredits()
    {
        HowToPlay.SetActive(false);
        if (Credits.activeSelf)
        {
            Credits.SetActive(false);
        }
        else
        {
            Credits.SetActive(true);
        }
    }
}
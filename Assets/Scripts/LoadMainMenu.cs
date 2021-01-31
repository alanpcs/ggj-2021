using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _items;

    void Start()
    {
        StartCoroutine(DisplayBaloons());
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator DisplayBaloons()
    {
        yield return new WaitForSeconds(0.01f);
        _items[0].SetActive(true);
        for (int i = 1; i < _items.Length; i++)
        {
            yield return new WaitForSeconds(0.8f);
            _items[i].SetActive(true);
        }
    }

}

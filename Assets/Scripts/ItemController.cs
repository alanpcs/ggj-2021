using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private bool _isLost;
    // Start is called before the first frame update
    void Start()
    {
        _isLost = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Yin")
        {
            Debug.Log("Amostra");
            _isLost = true;
        }
        else
        {
            Debug.Log("Outra coisa entra");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Yin")
        {
            Debug.Log("Xispa daqui");
            _isLost = false;
        }
        else
        {
            Debug.Log("Outra coisa sai");
        }
    }
}

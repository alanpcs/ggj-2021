using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
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
            _isLost = true;
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Yin")
        {
            _isLost = false;
        }
    }

    public bool GetIsLost()
    {
        return _isLost;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    private int _totalSocks;
    private int _lostSocks;

    void Start()
    {
        _totalSocks = 2;
        _lostSocks = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -0.1f), Space.Self);

        UpdateSocksQty();
    }

    private void UpdateSocksQty()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        _totalSocks = items.Length;
        _lostSocks = 0;
        foreach (GameObject item in items)
        {
            bool isLost = item.GetComponent<ItemController>().GetIsLost();
            if (isLost)
                _lostSocks++;
        }
        Debug.Log("Total: " + _totalSocks + " Lost: " + _lostSocks);
    }
}

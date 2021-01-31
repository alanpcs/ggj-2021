using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    private int _totalSocks;
    private int _lostSocks;
    private bool _canChangePos;
    private Vector3 _newPos;
    private Vector3 _deltaPos;
    private float translationSpeed = 4;

    void Start()
    {
        _totalSocks = 2;
        _lostSocks = 1;
        StartCoroutine(UpdatePosition());
        _canChangePos = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -0.1f), Space.Self);
        UpdateSocksQty();
        if (_canChangePos)
        {
            float move = translationSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _deltaPos, move);
            Vector3 remainingAnim = _newPos - transform.position;
            if (remainingAnim.magnitude < 0.01f)
                _canChangePos = false;
        }
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
    }

    IEnumerator UpdatePosition()
    {
        yield return new WaitForSeconds(1.0f);

        _canChangePos = true;

        float balance = (float)_lostSocks / _totalSocks - 0.5f;
        // balance will range from -0.5f to 0.5f
        _deltaPos = new Vector3(balance * 2 * 4.3f, transform.position.y, 0);

        //float translationSpeed = 4;
        //float move = translationSpeed * Time.deltaTime;

        _newPos = transform.position + _deltaPos;

        Debug.Log("Total: " + _totalSocks + " Lost: " + _lostSocks + " Balance: " + balance);

        StartCoroutine(UpdatePosition());
    }
}

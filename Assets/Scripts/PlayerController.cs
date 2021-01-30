using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _canPick;
    private bool _isHoldingItem;
    private GameObject _item;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Olar");
    }

    
    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 10;
        //Define the speed at which the object moves.

        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.

        CheckBoundaries();
        CheckPickItem();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!_isHoldingItem && col.tag == "Item")
        {
            Debug.Log("pega a meinha aí poxa");
            _canPick = true;
            _item = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (!_isHoldingItem && col.tag == "Item")
        {
            Debug.Log("af seu bobo não pegou a meia poxa, que decepção :(");
            _canPick = false;
            _item = null;
        }
    }

    void CheckPickItem()
    {
        if (Input.GetButtonDown("Action"))
        {
            if (_isHoldingItem)
            {
                Debug.Log("drop");
                _item.SetActive(true);
                _item.transform.position = transform.position;
                _isHoldingItem = false;
            }
            else
            {
                if (_canPick)
                {
                    _isHoldingItem = true;
                    Debug.Log("pegoouuu");
                    _item.SetActive(false);
                }
                else
                    Debug.Log("errouuuuu");
            }
        }
    }

    private void CheckBoundaries()
    {
        if (transform.position.x >= 8)
        {
            Vector3 pos = transform.position;
            pos.x = 8;
            transform.position = pos;
        }
        else if (transform.position.x <= -8)
        {
            Vector3 pos = transform.position;
            pos.x = -8;
            transform.position = pos;
        }
        if (transform.position.y >= 4.4f)
        {
            Vector3 pos = transform.position;
            pos.y = 4.4f;
            transform.position = pos;
        }
        else if (transform.position.y <= -4.4f)
        {
            Vector3 pos = transform.position;
            pos.y = -4.4f;
            transform.position = pos;
        }
    }
}

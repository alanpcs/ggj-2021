using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _canPick;
    private bool _isHoldingItem;
    private GameObject _item;
    private float moveSpeed;

    [SerializeField]
    private SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 4;
    }

    
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        //Check if the sprite needs to be fliped
        UpdateSprite(horizontalInput);

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.

        CheckBoundaries(horizontalInput, verticalInput);
        CheckPickItem();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!_isHoldingItem && col.tag == "Item")
        {
            Debug.Log("pega a meinha a? poxa");
            _canPick = true;
            _item = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (!_isHoldingItem && col.tag == "Item")
        {
            Debug.Log("af seu bobo n?o pegou a meia poxa, que decep??o :(");
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

    private void CheckBoundaries(float x, float y)
    {
        Vector3 newPosition = moveSpeed * Time.deltaTime * new Vector3(x, y, 0) + transform.position;

        float r = 4.4f;

        float distance = newPosition.x * newPosition.x + newPosition.y * newPosition.y;

        if (distance < (r * r))
        {
            transform.position = newPosition;
        } 
    }

    private void UpdateSprite (float x)
    {
        if (x < 0)
            _sprite.flipX = true;
        else if (x > 0)
            _sprite.flipX = false;

    }
}

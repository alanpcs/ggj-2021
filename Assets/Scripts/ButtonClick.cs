using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField]
    private AudioSource ClickSound;

    public void cachorro()
    {
        ClickSound.Play();
    }
}

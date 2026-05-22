using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            winUI.SetActive(true);
            

        }
    }
}


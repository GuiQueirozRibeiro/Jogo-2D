using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject nextLevel;
    
    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            nextLevel.SetActive(true);
        }
    }
}
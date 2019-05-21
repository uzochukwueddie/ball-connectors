using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public float vol;
    private bool hasCollided = false;

    void Start()
    {
        hasCollided = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Maze")
        {
			//Debug.Log("ho gia");
            GamePlay.instance.GameOver();
        }
    }
}

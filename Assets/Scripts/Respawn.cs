using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector2 startPos;

    AudioManager audioManager;

    private void Awake()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio"); 
        AudioManager audioManager = audioObject.GetComponent<AudioManager>();
    }
    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathVoid"))
        {
            Die();
        }
    }
    void Die()
    {
        Reespawn();
    }
    void Reespawn()
    {
        transform.position = startPos;
    }
}

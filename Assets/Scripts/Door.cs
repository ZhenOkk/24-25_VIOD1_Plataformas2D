using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null && inventory.hasKey && !isOpen)
            {
                OpenDoor();
                SceneManager.LoadScene("MenuPrincipal");
            }
            else
            {
                Debug.Log("Necesitas una llave para abrir esta puerta.");
            }
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        gameObject.SetActive(false);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] GameObject victoryPanel;
    [SerializeField] AudioClip levelSound;
    [SerializeField] AudioSource levelComplete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            victoryPanel.SetActive(true);
            levelComplete.PlayOneShot(levelSound);
        }
    }
}

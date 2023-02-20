using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    [SerializeField] GameObject resetPosition;
    [SerializeField] GameObject[] abilities;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = resetPosition.transform.position;
        collision.gameObject.transform.right = new Vector2(1, 0);
        for (int i = 0; i < abilities.Length; i++)
        {
            if (!abilities[i].activeSelf)
            {
                abilities[i].SetActive(true);
            }
        }
    }
}

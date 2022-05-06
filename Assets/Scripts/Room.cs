using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Room : MonoBehaviour
{
    [SerializeField] CinemachineStateDrivenCamera virtualCam;
    [SerializeField] Monster[] monsters;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            virtualCam.Priority = 10;
            Debug.Log(gameObject.name + " enabled");
            int len = monsters.Length;
            for (int i = 0; i < len; i++)
            {
                monsters[i].Activate();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            virtualCam.Priority = 0;
            Debug.Log(gameObject.name + " disable");
            int len = monsters.Length;
            for (int i = 0; i < len; i++)
            {
                monsters[i].Deactivate();
            }
        }
    }
}

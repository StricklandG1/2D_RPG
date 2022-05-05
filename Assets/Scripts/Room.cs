using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CinemachineStateDrivenCamera virtualCam;
    //[SerializeField] GameObject virtualCam2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            virtualCam.Priority = 10;
            Debug.Log(gameObject.name + " enabled");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            virtualCam.Priority = 0;
            Debug.Log(gameObject.name + " disable");
        }
    }
}

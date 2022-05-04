using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject virtualCam1;
    //[SerializeField] GameObject virtualCam2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            virtualCam1.SetActive(true);
            //virtualCam2.SetActive(true);
            Debug.Log(gameObject.name + " enabled");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            virtualCam1.SetActive(false);
            //virtualCam2.SetActive(false);
            Debug.Log(gameObject.name + " disable");
        }
    }
}

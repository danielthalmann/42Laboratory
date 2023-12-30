using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject player = null;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (!player)
            return;

        if (Input.GetAxis("Horizontal") != 0f)
        {
            player.transform.Translate(Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") != 0f)
        {
            player.transform.Translate(Vector3.up * speed * Input.GetAxis("Vertical") * Time.deltaTime);
        }


    }
}

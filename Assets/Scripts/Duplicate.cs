using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicate : MonoBehaviour
{
    public GameObject duplicate;
    public int amount = 2;
    public float speed = 1.0f;
    public float minimalDistance = 1.0f;

    private List<GameObject> chains;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position;
        chains = new List<GameObject>();

        for (int i = 0; i < amount; i++)
        {
            GameObject newObject = Instantiate(duplicate, this.transform);
            chains.Add(newObject);
        }

        Debug.Log(chains.Count);

        PlayerMove move = GetComponent<PlayerMove>();
        if (move != null)
        {
            move.player = chains[0];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist;
        for (int i = 1; i < amount; i++)
        {
            dist = Vector3.Distance(chains[i].transform.position, chains[i - 1].transform.position);

            if (dist > minimalDistance)
                chains[i].transform.position = Vector3.Lerp(chains[i].transform.position, chains[i - 1].transform.position, speed * Time.deltaTime);
            /*
            else if(dist < minimalDistance - 0.2f)
            {
                Vector3 diff = chains[i].transform.position - chains[i - 1].transform.position;
                chains[i].transform.position = Vector3.Lerp(chains[i].transform.position, diff, speed * Time.deltaTime);
            }
            */
        }
    }
}

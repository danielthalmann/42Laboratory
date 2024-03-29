using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public float interval = 1.0f;

    private float time = 0f;
    private int count = 0;
    private int wave = 0;
    private bool startWave = false;

    public List<EnemyWaves> waves;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (wave < waves.Count) { 

            time += Time.deltaTime;

            if (!startWave)
            {
                if (time > waves[wave].startAfter)
                {
                    startWave = true;
                    time = waves[wave].interval;
                }

            } else {

                if (time > waves[wave].interval) { 
        
                    GameObject obj = Instantiate(waves[wave].enemy);
                    FollowPath follow = obj.GetComponent<FollowPath>();

                    follow.path = waves[wave].path;
                    time = 0;
                    count++;
                }

                if (count >= waves[wave].count)
                {
                    wave++;
                    count = 0;
                    startWave = false;
                }


            }

        }



    }
}

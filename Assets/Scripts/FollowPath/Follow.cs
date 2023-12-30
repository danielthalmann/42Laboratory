using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public List<Transform> vectors = new List<Transform>();
    public Transform target;
    [Range(0f, 100f)]
    public float speed = 30.0f;

    private float direction = +1.0f;
    private float currentT = 0.0f;
    private int currentSegment = 0;


    // Start is called before the first frame update
    void Start()
    {
        target.position = vectors[0].position;
        
    }

    // Update is called once per frame
    void Update()
    {

        currentT += (1.0f / (50.0f / speed)) * Time.deltaTime * direction;
        if (currentT > 1.9f)
        {
            currentT = 1.9f;
        }
        if (currentT < -1.9f)
        {
            currentT = -1.9f;
        }

        if (currentT > 1.0f) 
        {
            currentSegment++;
            if (currentSegment < (vectors.Count / 3))
            {
                currentT -= 1.0f;

            } else {
                
                currentT = 1.0f;
                direction = -direction;
                currentSegment--;
            }

        } else if (currentT < 0.0f)
        {
            currentSegment--;
            if (currentSegment > -1)
            {
                currentT += 1.0f;
            } else
            {
                currentT = 0.0f;
                direction = -direction;
                currentSegment++;
            }
        }

        target.position = bezier(
            vectors[(currentSegment * 3) + 0].position, 
            vectors[(currentSegment * 3) + 1].position, 
            vectors[(currentSegment * 3) + 2].position, 
            vectors[(currentSegment * 3) + 3].position, currentT);


    }

    
    void OnDrawGizmos()
    {
        if (vectors.Count < 4)
            return;

        float steps = 1.0f / speed;

        Gizmos.DrawSphere(vectors[0].position, 0.5f);

        for (int i = 0; i < (vectors.Count / 3) ; i++)
        {

            for ( float t = steps; t < 1.0f; t += steps)
            {
                Vector3 p = bezier(vectors[0 + (i * 3)].position, vectors[1 + (i * 3)].position, vectors[2 + (i * 3)].position, vectors[3 + (i * 3)].position, t);
                Gizmos.DrawSphere(p, 0.5f);
            }

        }

        Gizmos.DrawSphere(vectors[vectors.Count - 1].position, 0.5f);

    }



    Vector3 bezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        float ap = Mathf.Pow((1.0f - t), 3.0f);
        float bp = 3.0f * t * Mathf.Pow((1.0f - t), 2.0f);
        float cp = 3.0f * (1.0f - t) * Mathf.Pow(t, 2.0f);
        float dp = Mathf.Pow(t, 3.0f);

        return new Vector3(
            a.x * ap + b.x * bp + c.x * cp + d.x * dp,
            a.y * ap + b.y * bp + c.y * cp + d.y * dp,
            a.z * ap + b.z * bp + c.z * cp + d.z * dp
        );

    }
}

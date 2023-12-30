using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class Raycasting : MonoBehaviour
{
    private Texture2D texture;
    private Size size;
    private SizeF viewport;

    public Material dest;

    // Start is called before the first frame update
    void Start()
    {
        viewport = new SizeF(1.0f, 1.0f);
        size = new Size(200, 200);
        texture = new Texture2D(size.Width, size.Height);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        float halfHeight = (viewport.Height / 2);
        float halfWidth = (viewport.Width / 2);

        for (float x = -halfWidth; x <= halfWidth; x += viewport.Width / size.Width)
        {
            for ( float y = -halfHeight; y <= halfHeight; y += viewport.Height / size.Height)
            {
                Vector3 v = new Vector3(x, y, 1.0f);
                ray = new Ray(transform.position, v);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 5.0f))
                {
                    //Debug.DrawRay(transform.position, transform.TransformDirection(v) * hit.distance, Color.yellow);
                    texture.SetPixel((int)((x + halfWidth) * size.Width / viewport.Width), (int)((y + halfHeight) * size.Height / viewport.Height), Color.blue);
                }
                else
                {
                    texture.SetPixel((int)((x + halfWidth) * size.Width / viewport.Width), (int)((y + halfHeight) * size.Height / viewport.Height), Color.green);
                }

                // Apply all SetPixel calls
                texture.Apply();

                // connect texture to material of GameObject t$$anonymous$$s script is attached to
                dest.mainTexture = texture;

            }
        }



    }
}

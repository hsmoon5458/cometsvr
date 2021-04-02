using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFalling : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector3 cube_falling_angle = new Vector3(0f, -1f, -0.8f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(cube_falling_angle * Time.deltaTime * speed);
        if(transform.position.y < 0.5)
        {
            Destroy(gameObject);
        }

    }

  
}

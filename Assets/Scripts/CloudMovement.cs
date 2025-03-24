using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public Rigidbody2D cloud;
    // Start is called before the first frame update
    void Start()
    {
        cloud = GetComponent<Rigidbody2D>();
        cloud.velocity = new Vector2(0.5f, 0);
    }
}

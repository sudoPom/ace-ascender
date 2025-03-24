using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player(Clone)");
        if (this.gameObject.transform.position.y - player.transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }
}

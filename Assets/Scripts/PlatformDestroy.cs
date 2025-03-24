using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    public float destructionTimer;
    private bool death = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       if(death == true)
        {
            destructionTimer -= Time.deltaTime;
            if(destructionTimer <= 0)
            {
                destroyer();
            }

        }

        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            death = true;
        }
    }

    private void destroyer()
    {
        Destroy(this.gameObject);
    }


}


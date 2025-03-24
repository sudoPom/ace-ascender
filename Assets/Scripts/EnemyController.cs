using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Rigidbody2D enemy;
    public float multiplier;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemy.velocity = new Vector3(multiplier, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x < -7)
        {
            enemy.velocity = new Vector3(multiplier, 0, 0);
            if(facingRight == false)
            {
                flip();
            }
        }
        else if(this.gameObject.transform.position.x > 7)
        {
            enemy.velocity = new Vector3(-multiplier, 0, 0);
            if(facingRight == true)
            {
                flip();
            }
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

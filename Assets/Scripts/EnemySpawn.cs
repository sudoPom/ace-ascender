using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private float x;
    private float y;
    private float z;
    private Vector3 enemyCoords;

    // Start is called before the first frame update
    void Start()
    {
        x = this.gameObject.transform.position.x;
        y = this.gameObject.transform.position.y + 1;
        z = this.gameObject.transform.position.z;
        enemyCoords = new Vector3(x, y, z);
        Instantiate(enemy, enemyCoords, Quaternion.identity);
    }


}

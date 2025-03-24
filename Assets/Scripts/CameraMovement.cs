using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    private Transform cameraPos;
    private double y;
    public float multiplier;
    public GameObject playerPos;

    // Start is called before the first frame update
    void Start()
    {
        cameraPos = this.gameObject.transform;
        y = 0.33f;
    }

    // Update is called once per frame
    void Update()
    {
        y += multiplier * Time.deltaTime;
        cameraPos.position = new Vector3(0, (float)y, -10);
        playerPos = GameObject.Find("Player(Clone)");
        if(playerPos.transform.position.y - cameraPos.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

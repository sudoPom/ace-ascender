using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    private float maxheight = 0;
    private int score;
    public Text dScore;
    private GameObject player;
    static public bool collected;
    private float prevHeight = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        maxheight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player(Clone)");
        if (maxheight < player.transform.position.y)
        {
            maxheight = player.transform.position.y;
        }
        score += (int)((maxheight - prevHeight) * 10);
        prevHeight = maxheight;
        if (collected)
        {
            score += 50;
            collected = false;
        }
        dScore.text = score.ToString();
    }
}

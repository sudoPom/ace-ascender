using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject player; 
    //private GameObject playerPos; //the coordinates of the player
    static int[] plat = new int[4]; //array that stores wether a point in space should have a platform spawned or not
    static float maxDistance = 20;
    private int n;
    private int[] randomNumbers = new int[8];



    static double platHeight = 5; // the height at which a platform is spawned above the platform below it
    Vector3 platCoordinates = new Vector3(0, 0, 0); //coordinates of where a platform should be spawned


    public GameObject ground; //A regular platform
    public GameObject trapPlatform; //A platform that dissapears on contact with the player
    public GameObject obstaclePlatform;
    public GameObject enemyPlatform;
    public GameObject coinPlatform;
    private bool enemySpawned;

    private void Start()
    {
        Instantiate(player, new Vector3(0, 1, 0),Quaternion.identity); //Spawns the player
    }

    void Update()
    {
            player = GameObject.Find("Player(Clone)");
            if ((platCoordinates.y - player.transform.position.y) < maxDistance)//If the distance between the player and the platform is less than 7 units then a new set of platforms will be spawned
                {
                float x = -16; //sets the x coordinate to the very left of the screen
                platCoordinates = new Vector3(x, (float)platHeight, 0); //Sets the coordinates of the platforms to be spawned
                plat = new int[8] {0, 0, 0, 0, 0, 0, 0, 0}; //Resets the platform array, making it empty
                plat = platlay(plat); //Adds up to two ones to the array
                enemySpawned = false;
                for (int i = 0; i < 8; i++) //loops 4 times to spawn 4 platforms
                {
                    if (plat[i] == 1) //if the ith value in the array is 1 then some platforms will be spawned.
                    {
                        for (int u = 0; u < 4; u++) //iterates from 0 to 5 spawning up to 5 ground tiles
                        {
                            randomNumbers = RNG(); //generates 5 random numbers and stores them in an array.
                            n = randomNumbers[u];
                            if (n > 5 && n <= 70)//if the uth number in the array is between 0 and 70 spawn a regular platform tile
                            {
                                Instantiate(ground, platCoordinates, Quaternion.identity);
                                platCoordinates.x += 1f; //move the next coordiniates of the next tile to be spawned to the right
                            }
                            else if (n < 5 && n >= 0)//if the uth number in the array is between 0 and 5 spawn a coin platform tile
                            {
                                Instantiate(coinPlatform, platCoordinates, Quaternion.identity);
                                platCoordinates.x += 1f; //move the next coordiniates of the next tile to be spawned to the right
                            }
                            else if (n > 70 && n <= 80) //if the nth number in the array is between 70 and 80 spawn a trap platform 
                            {
                                Instantiate(trapPlatform, platCoordinates, Quaternion.identity);
                                platCoordinates.x += 1f;
                            }
                            else if(n > 80 && n <= 90) // If the number is greater than 80 and less than or equal to 90 don't spawn anything
                            {
                                platCoordinates.x += 1f;
                            }
                            else if (n > 90 && n <= 95) //if the number is greater than 90 then spawn a obstacle platform
                            {
                                Instantiate(obstaclePlatform, platCoordinates, Quaternion.identity);
                            platCoordinates.x += 1f;
                            }
                            else if (n > 95 && enemySpawned == false && n <= 100) //if the number is greater than 90 then spawn a obstacle platform
                            {
                                Instantiate(enemyPlatform, platCoordinates, Quaternion.identity);
                                enemySpawned = true;
                                platCoordinates.x += 1f;
                            }

                        }
                    }
                    else if(plat[i] == 0) //if the ith number in the array is 0 don't spawn any platforms.
                    {
                        platCoordinates.x += 4f; 
                    }
                }
                platHeight += getHeight(); //Increases the y value of the next set of platforms to be spawned.
            }
    }

    int[] platlay(int[] p)
    {
        System.Random rdm = new System.Random();
        int a = rdm.Next(0, 8);
        int b = rdm.Next(0, 8);
        int c = rdm.Next(0, 8);
        p[a] = 1;
        p[b] = 1;
        p[c] = 1;
        return p;
    }

    double getHeight()
    {
        double a = Random.Range(6, 8);
        return a;
    }
    
    int[] RNG()
    {
        System.Random rdm = new System.Random();
        int a = rdm.Next(0, 100);
        int b = rdm.Next(0, 100);
        int c = rdm.Next(0, 100);
        int d = rdm.Next(0, 100);
        int e = rdm.Next(0, 100);
        return new int[] {a,b,c,d,e};
    }
}
   

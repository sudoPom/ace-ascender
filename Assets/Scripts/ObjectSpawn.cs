using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    private float x; //the coordinates for where the object will be spawned
    private float y;
    public GameObject Object; //the object to be spawned
    // Start is called before the first frame update
    void Start()
    {
        x = this.gameObject.transform.position.x; //takes the x coordinate of the platform 
        y = this.gameObject.transform.position.y + 2; //takes the y coordinate of the platform and increases it by 2
        Instantiate(Object, new Vector3(x, y, 0), Quaternion.identity); //spawns the object at the coordinates stated above
    }
}


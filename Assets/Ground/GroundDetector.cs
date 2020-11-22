using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    // Make sure to assign this in the inspector so it knows what the coin should be.
    public GameObject Obstacle_3;
    //Change this in the inspector to determine how often it should try to spawn the coin.
    public float CheckSpawnRate;
    float countDown;
    Vector3 coinPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        countDown -= 1f * Time.deltaTime;
        if (countDown <= 0f)
        {
            RandomCoin();
            countDown = CheckSpawnRate;
        }
    }
    public void RandomCoin()
    {
        //Check the "1" From 1 to any other number and that will determine how likely it is to spawn a coin.

        int r = Random.Range(0, 1);
        if (r == 0)
        {
            RaycastHit hit;
            //This is where it checks the ground height.
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                coinPos = hit.point;
                //The draw ray isn't required but it shows you a laser beam of where it is looking. Keep in mind it shoots from the bottom of the object the script is attatched to.
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
            Instantiate(Obstacle_3, coinPos, Quaternion.identity);
        }
    }
}
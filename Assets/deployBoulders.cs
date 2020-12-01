using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployBoulders : MonoBehaviour
{
    public GameObject boulderPrefab;
    public float respawnTime = 5f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(boulderWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(boulderPrefab) as GameObject;
        a.transform.position = new Vector3(Random.Range(-2, screenBounds.x), -2, 0);
    }
    IEnumerator boulderWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}

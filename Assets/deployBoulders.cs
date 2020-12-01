using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployBoulders : MonoBehaviour
{
    public GameObject boulderPrefab;
    public float respawnTime = 1.0f;
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
        a.transform.position = new Vector2(Random.Range(0, screenBounds.x), screenBounds.y * 2);
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

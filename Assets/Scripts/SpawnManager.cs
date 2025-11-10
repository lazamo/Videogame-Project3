using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerController playerControllerScript;
    public GameObject obstacleprefab;
    public Vector3 startPos = new Vector3(25f, 0f, -1.1f);
    public float spawnDelay = 1.8f;
    public float spawnInterval;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnInterval = Random.Range(2f, 2.5f);
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void SpawnObstacle() 
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstacleprefab, startPos, obstacleprefab.transform.rotation);
        }
        
    }

}

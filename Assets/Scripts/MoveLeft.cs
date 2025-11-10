using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed = 30.0f;
    public PlayerController playerControllerScript;
    public float leftBound = -20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false) 
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       
        if (transform.position.x < leftBound && CompareTag("Obstacle")) 
        {
            Destroy(gameObject);
        }
    }
}

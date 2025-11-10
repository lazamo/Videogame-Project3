using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Animator playerAnimation;
    public AudioSource playerAudio;
    public ParticleSystem explasionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 6.0f;
    public float gravityModifier = 1.5f;
    public bool isOnGround = true;
    public bool gameOver = false;

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) 
        { 
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            explasionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
           
        
    }
}

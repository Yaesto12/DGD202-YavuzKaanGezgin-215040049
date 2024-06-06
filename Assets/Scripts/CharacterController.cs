using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    private Vector3 startPosition;
    private Quaternion startRotation;
    public AudioClip jumpSound;
    public AudioClip coinSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(isGrounded && Input.GetKey(KeyCode.Space))
        {
            audioSource.PlayOneShot(jumpSound);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Killer"))
        {
            Respawn();
        }
        if(collision.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinSound);
        }
        if(collision.CompareTag("EndPoint"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Respawn()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }


}

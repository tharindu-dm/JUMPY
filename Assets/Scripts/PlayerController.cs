using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 12;
    public float gravityModifier;
    public bool isOnPlatform = true;
    public bool gameOver = false;

    private Vector3 currentRotation; 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        currentRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isOnPlatform)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnPlatform = false;
        }

        if(transform.position.y < -2f)
            gameOver = true; 
        
        if (currentRotation.x <= -90f || currentRotation.x >= 270f)
        {
            // Target rotation (right-side up, facing the correct direction)
            Quaternion targetRotation = Quaternion.Euler(0f, -90f, 0f);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            gameOver = true;
            Debug.Log("Game Over!!!");
        }
    }

}
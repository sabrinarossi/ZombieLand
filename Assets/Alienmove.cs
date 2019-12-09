using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alienmove : MonoBehaviour
{


    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Text countText;
    public Text winText;

    private Vector3 moveDirection = Vector3.zero;
    private int count;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void Update()
    {
        if (characterController.isGrounded)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }


        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Treasure Chest"))


        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            Debug.Log(count);
        }
    }

    void SetCountText()
        {
            countText.text = "Count: " + count.ToString();
            if (count >= 11)
            {
                winText.text = "You Win!";
            }


        }

    }









       
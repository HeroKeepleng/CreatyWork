using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject effect;

    public float moveSpeed;
    public int keys;


    private void Start()
    {
        gameManager.GetComponent<GameManager>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Key"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            keys++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("DoorPan") && keys == 6)
        {
            gameManager.isOpen = true;
        }
        if (other.gameObject.name == "WinWall")
        {
            gameManager.isWin = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {

        }
    }
}

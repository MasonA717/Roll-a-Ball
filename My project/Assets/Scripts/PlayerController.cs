using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private float movementX, movementY;
    private int count;

    // At the start of the game..
    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce (movement * speed);
    }

    void OnMove(InputValue value) {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag ("PickUp")) {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();

        if (count >= 12) {
            winTextObject.SetActive(true);
        }
    }
}
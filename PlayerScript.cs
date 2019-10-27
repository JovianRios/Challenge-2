using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    private bool facingRight = true;

    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    private int count;
    private int lives;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetCountText();
        facingRight = true;
    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText();
            livesText.text = "Lives Left: " + lives.ToString();
            if (lives <= 0)
            {
                loseText.text = "You Lose!";
            }
            if (lives <= 0) Destroy(this);
        }
        if (count == 4)
        {
            transform.position = new Vector2(90.0f, 0.0f);
        }
    }
        private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }
        void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 8)
        {
            winText.text = "You win! Game created by Jovian Rios!";
        }
        if (count == 8) Destroy(this);
    }
}

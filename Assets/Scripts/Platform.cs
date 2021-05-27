using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private bool hasScored;
    public Text scoreText;

    private float score;
    // Start is called before the first frame update
    void Start()
    {
        score = int.Parse(scoreText.text);
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)) * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < screenBounds.x && !hasScored){
            hasScored = true;
            scoreText.text = (int.Parse(scoreText.text)+5).ToString();
        }
        if(transform.position.x < screenBounds.x * 2){
            Destroy(this.gameObject);
            Debug.Log("Destroyed");
        }
    }
}

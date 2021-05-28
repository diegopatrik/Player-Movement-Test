using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)) * -1;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            Debug.Log("Hit by rockkk");
            Invoke("kill", 0.2f);
        }
    }

    void kill(){
        SceneManager.LoadScene("GameOver");
    }


    void Update()
    {
        if(transform.position.x < screenBounds.x * 10){
            Destroy(this.gameObject);
        }
    }
}

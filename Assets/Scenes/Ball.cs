using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TextMeshProUGUI helptxt;
    [SerializeField]
    float speed;
    float radius;
    Vector2 direction;
    bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteCanvasAfterDelay());
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
        transform.Translate(direction * speed * Time.deltaTime);
        if(transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
            direction.y = -direction.y;
        if(transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
            direction.y = -direction.y;
        if(transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0){
            Debug.Log("Right Player Wins!!");
            Time.timeScale = 0;
            enabled = false;
        }
        if(transform.position.x > GameManager.topRight.x - radius && direction.x > 0){
            Debug.Log("Left Player Wins!!");
            Time.timeScale = 0;
            enabled = false;
        }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Paddle"){
            bool isRight = other.GetComponent<Paddle>().isRight;
            if(isRight == true && direction.x > 0)
                direction.x = -direction.x;
            if(isRight == false && direction.x < 0)
                direction.x = -direction.x;
        }
    }
    IEnumerator DeleteCanvasAfterDelay()
    {
        Debug.Log("Coroutine started");
        // Wait for 10 seconds
        yield return new WaitForSeconds(5f);

        // Find the Canvas with the specified tag
        GameObject canvas = GameObject.FindGameObjectWithTag("Help Screen");

        // Check if the Canvas is found
        if (canvas != null)
        {
            // Destroy the Canvas GameObject
            Destroy(canvas);
        }
        else
        {
            Debug.LogError("Canvas with tag '" + "Help Screen" + "' not found!");
        }
        canMove = true;
    }
}

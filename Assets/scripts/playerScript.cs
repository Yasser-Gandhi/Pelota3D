using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float fordwardSpeed;
    public float sideForce;
    // Start is called before the first frame update

    int halfScreen;

    void Start()
    {
        halfScreen = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, 0, fordwardSpeed)* Time.deltaTime);
        
        if (Input.GetKey(KeyCode.A))
        {
                    rb.AddForce(new Vector3(-sideForce, 0, 0)* Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
                    rb.AddForce(new Vector3(sideForce, 0, 0)* Time.deltaTime);
        }

        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).position.x <= halfScreen)
            {
                rb.AddForce(new Vector3(-sideForce, 0, 0)* Time.deltaTime);
            }

             if(Input.GetTouch(0).position.x > halfScreen)
            {
                rb.AddForce(new Vector3(sideForce, 0, 0)* Time.deltaTime);

            }

        }

        if(transform.position.y < -3)
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

}

using System.Collections;
using UnityEngine;

public class SubMovement : MonoBehaviour
{
    // public variables

    public float movementSpeed; // = 100f;
    public float rotationSpeed; // = 5f;
    public float maxSpeed;

    public GameObject[] propellers;
    public float propChangeRate;
    public ParticleSystem[] bubbles;

    public AudioClip hit;


    // private variables
    private float surfaceHeight = 450.2f;


    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }


    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            forward();
            propellers[2].GetComponent<Animation>().CrossFade("FastSpin", propChangeRate);
            propellers[3].GetComponent<Animation>().CrossFade("FastSpin", propChangeRate);
            bubbles[2].emissionRate = 100f;
            bubbles[3].emissionRate = 100f;
        }
        else
        {
            propellers[2].GetComponent<Animation>().CrossFade("SlowSpin", propChangeRate);
            propellers[3].GetComponent<Animation>().CrossFade("SlowSpin", propChangeRate);
            bubbles[2].emissionRate = 10f;
            bubbles[3].emissionRate = 10f;
        }
        // if (Input.GetKey("s"))
        // {
        //     backward();
        // }

        if (transform.position.y < surfaceHeight)
        {


            if (Input.GetKey(KeyCode.Space))
            {
                up();
                propellers[0].GetComponent<Animation>().CrossFade("FastSpin", propChangeRate);
                propellers[1].GetComponent<Animation>().CrossFade("FastSpin", propChangeRate);
                bubbles[0].emissionRate = 100f;
                bubbles[1].emissionRate = 100f;
                // foreach(GameObject prop in propellers)
                // {	
                // 	prop.GetComponent<Animation>().CrossFade("FastSpin", propChangeRate);
                // }

                // foreach(ParticleSystem bubble in bubbles)
                // {
                // 	bubble.emissionRate = 100f;
                // }
            }
            else
            {
                propellers[0].GetComponent<Animation>().CrossFade("SlowSpin", propChangeRate);
                propellers[1].GetComponent<Animation>().CrossFade("SlowSpin", propChangeRate);
                bubbles[0].emissionRate = 10f;
                bubbles[1].emissionRate = 10f;
                // foreach (GameObject prop in propellers)
                // {
                //     prop.GetComponent<Animation>().CrossFade("SlowSpin", propChangeRate);
                // }

                // foreach (ParticleSystem bubble in bubbles)
                // {
                //     bubble.emissionRate = 10f;
                // }
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            down();
        }

        if (Input.GetKey("a"))
        {
            propellers[3].GetComponent<Animation>().CrossFade("FastSpin", propChangeRate);
            bubbles[3].emissionRate = 100f;
        }
        // else
        // {
        //     propellers[3].GetComponent<Animation>().CrossFade("SlowSpin", propChangeRate);
        //     bubbles[3].emissionRate = 10f;
        // }

        if (Input.GetKey("d"))
        {
            propellers[2].GetComponent<Animation>().CrossFade("FastSpin", propChangeRate);
            bubbles[2].emissionRate = 100f;
        }
        // else
        // {
        //     propellers[2].GetComponent<Animation>().CrossFade("SlowSpin", propChangeRate);
        //     bubbles[2].emissionRate = 10f;
        // }

        // Rotation
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rotate(rotation);


        // Keep in water
        if (transform.position.y >= surfaceHeight)
        {
            Vector3 temp = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
            GetComponent<Rigidbody>().velocity = temp;
        }

    }


    /***************************
	 Control Functions
	**************************/
    void up()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * movementSpeed, ForceMode.Acceleration);
    }

    void down()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.down * movementSpeed, ForceMode.Acceleration);
    }

    void forward()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
            GetComponent<Rigidbody>().AddForce(transform.forward * movementSpeed, ForceMode.Acceleration);

    }

    void backward()
    {
        GetComponent<Rigidbody>().AddForce(-1 * transform.forward * movementSpeed, ForceMode.Acceleration);
    }

    void rotate(float rotation)
    {
        GetComponent<Rigidbody>().freezeRotation = false;
        transform.Rotate(0, rotation, 0);
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().PlayOneShot(hit);
    }

}



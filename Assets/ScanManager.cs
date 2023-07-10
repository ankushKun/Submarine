using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScanManager : MonoBehaviour
{
    public Camera piCam;
    public GameObject[] codes;
    public TMP_Text scanText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scanText.text = "Scan: ";
        foreach (GameObject code in codes)
        {
            // check if code is in the view of Camera piCam
            if (code.GetComponent<Renderer>().isVisible)
            {
                // if so, check if the code is in the center of the view
                Vector3 screenPoint = piCam.WorldToViewportPoint(code.transform.position);
                bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

                if (onScreen)
                {
                    // if so, check if the code is in the center of the view
                    float distance = Vector3.Distance(piCam.transform.position, code.transform.position);
                    // Debug.Log(code + " is in the center of the view " + distance);
                    // get distance of piCam to code
                    if (distance <= 100f && distance > 20f)
                    {
                        Debug.Log(code + " is close enough to scan");
                        scanText.text = "Scan: " + code.name;
                    }
                }
                // else
                // {
                //     // if not, check if the code is in the view
                //     Debug.Log(code + " is in the view");
                // }
            }
            // else
            // {
            //     // if not, check if the code is in the view
            //     Debug.Log(code + " is not in the view");
            // }
        }
    }
}

using System.Collections;
using UnityEngine;

public class master : MonoBehaviour
{

    public Texture2D fullscreenTexture;
    public Texture2D unfullscreenTexture;
    public Transform frontProps;

    public static int fishCaught;

    void Start()
    {
        fishCaught = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
        frontProps.localPosition = new Vector3(0, 0, 0.3f);
        frontProps.localRotation = Quaternion.Euler(90, 0, 0);
    }

    // void OnGUI()
    // {

    //     // FishCaught
    //     GUI.Box(new Rect(Screen.width - 110, 10, 100, 30), "Fish caught: " + fishCaught);




    //     // Fullscreen toggle 
    //     bool full = Screen.fullScreen;

    //     if (!full)
    //     {
    //         if (GUI.Button(new Rect(Screen.width - 140, Screen.height - 60, 70, 50), "Full"))
    //         {
    //             Screen.fullScreen = !Screen.fullScreen;
    //         }
    //     }
    //     else
    //     {
    //         if (GUI.Button(new Rect(Screen.width - 140, Screen.height - 60, 70, 50), "Exit Full"))
    //         {
    //             Screen.fullScreen = !Screen.fullScreen;
    //         }
    //     }

    // }
}

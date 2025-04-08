using System.Threading;
using Scrpts;
using Unity.VisualScripting;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            UtilsScreen.MinimizeAllWindows();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            UtilsScreen.ShowDesktop();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            UtilsScreen.CaptureScreen();
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            UtilsScreen.MinimizeAllWindows();
            UtilsScreen.ShowDesktop();
            Thread.Sleep(500);
            UtilsScreen.CaptureScreen();
            UtilsScreen.ShowDesktop();
        }
    }
}

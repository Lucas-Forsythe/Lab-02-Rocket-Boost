using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed. Quitting application.");
            Application.Quit();
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("Escape key pressed. Quitting application.");
            Application.Quit();
        }
    }
}

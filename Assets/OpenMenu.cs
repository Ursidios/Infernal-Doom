using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject Menu;

    public static bool isMenuOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isMenuOpen = Menu.activeSelf;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(!isMenuOpen);
        }
        if(isMenuOpen)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void OpenMenuOBJ()
    {
        Menu.SetActive(true);
    }
}

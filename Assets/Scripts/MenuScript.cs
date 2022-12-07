using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //[SerializeField]
    //private AudioSource wizard;

    [SerializeField]
    private Image startImage;


    [SerializeField]
    private Image exitImage;

    [SerializeField]
    private GameObject novamente;


    private Color unselectedColor = new Color(255, 255, 0);
    private Color selectedColor = new Color(104, 0, 212);

    private int selection = 0;


    void Start()
    {
        //wizard.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LTrigger"))
        {
            if ((selection == 0) || (selection == 2))
            {
                startImage.color = selectedColor;
                exitImage.color = unselectedColor;
                selection = 1;
                novamente.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Game Play");
            }
        }
        if (Input.GetButtonDown("RTrigger"))
        {

            if ((selection == 0) || (selection == 1))
            {
                exitImage.color = selectedColor;
                startImage.color = unselectedColor;
                selection = 2;
                novamente.SetActive(true);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}

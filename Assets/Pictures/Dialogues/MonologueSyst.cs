using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueSyst : MonoBehaviour
{

    public Image[] MonoSys;
    private int currentIndex = 0;
    public PlayerController playerController;

    public int requiredClicks = 7;
    private int currentClickCount = 0;
    public GameObject undertaleObject;

    public AudioSource dialog;



    public void Start()
    {
        undertaleObject.SetActive(false);
        if (MonoSys.Length > 0)
        {
            MonoSys[0].enabled = true;
        }
    }

    public void Update()
    {

        ChangeWindow();

        if (currentClickCount >= requiredClicks)
        {
            ShowUndertale();
        }

        if (currentIndex < MonoSys.Length)
        {

            playerController.Dialog();
        }

    }


    public void ChangeWindow()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            currentClickCount++;

            if (currentIndex < MonoSys.Length)
            {

                Destroy(MonoSys[currentIndex].gameObject);

                currentIndex++;


                if (currentIndex < MonoSys.Length)
                {
                    dialog.Play();
                    MonoSys[currentIndex].enabled = true;
                }
                else
                {
                    playerController.Unfreeze();
                }
            }
        }
    }


    public void ShowUndertale()
    {

        undertaleObject.SetActive(true);
    }
}
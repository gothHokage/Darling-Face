using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMonologueSystem : MonoBehaviour
{
    public Image[] dialogueImages;  // ’ранит все изображени€ дл€ диалогов или монологов
    private int currentIndex = 0;
    public PlayerController playerController;
    public AudioSource dialog;

    private bool isDialogueActive = false;  // ѕеременна€ дл€ отслеживани€ активности диалога

    public void StartDialogueOrMonologue()
    {
        if (dialogueImages.Length > 0)
        {
            dialog.Play();
            dialogueImages[0].enabled = true;
            currentIndex = 0;
            isDialogueActive = true;
            playerController.Dialog();  // ќстанавливаем движение
        }
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            AdvanceDialogue();
        }
    }

    void AdvanceDialogue()
    {
        if (currentIndex < dialogueImages.Length)
        {
            Destroy(dialogueImages[currentIndex].gameObject);

            currentIndex++;
            if (currentIndex < dialogueImages.Length)
            {
                dialog.Play();
                dialogueImages[currentIndex].enabled = true;
            }
            else
            {
                EndDialogue();
            }
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        playerController.Unfreeze();  // ¬озвращаем контроль игроку
    }
}

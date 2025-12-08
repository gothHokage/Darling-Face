using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public Collider2D playerColl;
    public Image ToggleKeyE;

    private bool isInTrigger = false;
    private string currentTriggerTag = "";

    public DialogueMonologueSystem dialogueSystem;

    public float transitionDelay = 2f;
    public Animator fadeAnimator;

    //audio
    public AudioSource Scene;

    public GameObject MONO;

    void Start()
    {
        ToggleKeyE.enabled = false;
        Scene.Stop();
    }

    void Update()
    {
        // Если игрок в зоне триггера и нажимает "E"
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (IsDialogueTag(currentTriggerTag))
            {
 
                dialogueSystem.StartDialogueOrMonologue();
            }
            else
            {

                StartCoroutine(HandleSceneTransition());
            }
        }
    }

    private IEnumerator HandleSceneTransition()
    {

        fadeAnimator.SetTrigger("FadeOut");


        
        Scene.Play();  
        

        yield return new WaitForSeconds(transitionDelay);


        switch (currentTriggerTag)
        {
            case "SmokingZone":
                SceneManager.LoadScene("Smoking Zone");
                break;
            case "UniverEnter":
                SceneManager.LoadScene("Guard");
                break;
            case "Guard Free":
                SceneManager.LoadScene("Guard Free");
                break;
            case "Coridors":
                SceneManager.LoadScene("Coridors");
                break;
            case "Outside":
                SceneManager.LoadScene("Outside");
                break;
            case "EndOutside":
                SceneManager.LoadScene("End Outside");
                break;
            case "Samosha":
                SceneManager.LoadScene("Samosha");
                break;
        }
    }

    // Когда игрок входит в триггерную зону
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsDialogueTag(other.tag) || IsSceneTag(other.tag))
        {
            ToggleKeyE.enabled = true;
            isInTrigger = true;
            currentTriggerTag = other.tag;

            // Если триггер с тегом "MONO", автоматически запускаем монолог
            if (other.tag == "MONO")
            {
                dialogueSystem.StartDialogueOrMonologue();
                MONO.SetActive(false);
            }
        }
    }

    // Когда игрок покидает триггерную зону
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(currentTriggerTag))
        {
            ToggleKeyE.enabled = false;
            isInTrigger = false;
            currentTriggerTag = "";
        }
    }

    // Проверяем, является ли тег триггера тегом для диалогов или монологов
    private bool IsDialogueTag(string tag)
    {
        return tag == "NPC" || tag == "MONO";  // Укажите теги, которые связаны с диалогами
    }

    // Проверка на теги для сцен
    private bool IsSceneTag(string tag)
    {
        return tag == "SmokingZone" || tag == "UniverEnter" || tag == "Coridors" || tag == "UniverOutside" || tag == "Samosha" || tag == "Outside" || tag == "Guard Free" || tag == "EndOutside";
    }
}

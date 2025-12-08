using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementHeart : MonoBehaviour
{
    // PHYSIC DATA
    public float speedValue = 3f;

    // PHYSICS
    public Rigidbody2D rigidBody;
    public Animator animHeart;

    public int health = 3;
    public ScreenShake screenShake;
    public AudioSource Hurt;
    public GameObject GameOver;

    // Длительность анимации урона
    public float damageAnimationDuration = 0.5f; // Измените это значение, если нужно

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animHeart = GetComponent<Animator>();
        GameOver.SetActive(false);
    }

    void FixedUpdate()
    {
        Walk();
    }

    public void Walk()
    {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speedValue, Input.GetAxis("Vertical") * speedValue);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damage"))
        {
            // Запускаем корутину для обработки урона
            StartCoroutine(HandleDamage());
        }
    }

    private IEnumerator HandleDamage()
    {
        Hurt.Play();
        animHeart.SetBool("IsDamageTaken", true);
        health--;
        screenShake.Shake();  // Тряска экрана
        

        // Ждем, пока длительность анимации урона не закончится
        yield return new WaitForSeconds(damageAnimationDuration);

        animHeart.SetBool("IsDamageTaken", false); // Устанавливаем IsDamageTaken обратно в false

        if (health <= 0)
        {
            GameOver.SetActive(true);
        }
    }

    public void ResetHealth()
    {
        health = 3;  // Сброс здоровья для нового раунда
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Перезапуск текущей сцены
    }
}

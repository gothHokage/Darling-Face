using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Подключаем для работы с UI

public class GameManager : MonoBehaviour
{
    public float roundTime = 30f;   // Время раунда
    public float restTime = 3f;     // Время отдыха
    public int points = 0;          // Количество очков
    public Text timerText;          // Ссылка на UI текст для таймера
    public Text pointsText;         // Ссылка на UI текст для очков
    public MovementHeart playerController;  // Ссылка на скрипт игрока для сброса здоровья

    private float timer;
    public bool isResting = false;

    void Start()
    {
        timer = roundTime;
        UpdateUI();  // Обновляем UI в начале
    }

    void Update()
    {
        if (!isResting)
        {
            timer -= Time.deltaTime;  // Уменьшаем таймер

            if (timer <= 0)
            {
                // Проверяем, если очков меньше 2, добавляем 1 очко
                if (points < 2)
                {
                    points++;  // Добавляем очки
                    playerController.ResetHealth();  // Сбрасываем здоровье игрока

                    if (points < 2)
                    {
                        StartCoroutine(RestPeriod());  // Если очков меньше 2, запускаем период отдыха
                    }
                    else
                    {
                        // Переход на следующую сцену после получения 2 очков
                        SceneManager.LoadScene("SamoshaWin");
                    }
                }
            }

            UpdateUI();  // Обновляем UI каждую итерацию
        }
    }

    // Корутин для периода отдыха между раундами
    IEnumerator RestPeriod()
    {
        isResting = true;
        timer = restTime;  // Таймер на отдых

        UpdateUI();  // Обновляем UI, чтобы отобразить время отдыха

        yield return new WaitForSeconds(restTime);  // Ждем заданное время отдыха

        timer = roundTime;  // Возвращаем время для нового раунда
        isResting = false;  // Снимаем флаг отдыха
    }

    // Метод для обновления UI
    void UpdateUI()
    {
        if (timerText != null)
        {
            timerText.text = "Timer: " + Mathf.Ceil(timer).ToString();  // Обновляем текст таймера
        }

        if (pointsText != null)
        {
            pointsText.text = "Points: " + points.ToString();  // Обновляем текст очков
        }
    }
}

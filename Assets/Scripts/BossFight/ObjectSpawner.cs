using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;   // Объект, который спавнится
    public float spawnInterval = 1f;   // Интервал спауна объектов
    public GameManager gameManager;     // Ссылка на GameManager для доступа к состоянию игры
    public Transform[] spawnPoints;     // Массив точек спавна объектов

    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        // Проверяем, идет ли отдых. Если отдых идет, объекты не спавним
        if (!gameManager.isResting)  // Проверяем флаг isResting из GameManager
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                SpawnObject();
                spawnTimer = spawnInterval;  // Сброс таймера на интервал спауна
            }
        }
    }

    void SpawnObject()
    {
        // Случайно выбираем точку спавна из массива
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Спавним объект на заданной позиции
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);

        // Устанавливаем направление движения объекта в зависимости от позиции спавна
        if (randomIndex == 0)  // Если это первая точка спавна
        {
            spawnedObject.GetComponent<MovingObject>().SetMovementDirection(Vector2.left);  // Движение слева
        }
        else if (randomIndex == 1)  // Если это вторая точка спавна
        {
            spawnedObject.GetComponent<MovingObject>().SetMovementDirection(Vector2.down);  // Движение вниз
        }
        else if (randomIndex == 2)  // Если это вторая точка спавна
        {
            spawnedObject.GetComponent<MovingObject>().SetMovementDirection(Vector2.right);  // Движение вниз
        }
        else if (randomIndex == 3)  // Если это вторая точка спавна
        {
            spawnedObject.GetComponent<MovingObject>().SetMovementDirection(Vector2.up);  // Движение вниз
        }


    }
}

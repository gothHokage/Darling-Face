using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f; // Скорость движения

    private Vector2 moveDirection;

    // Метод для установки направления движения
    public void SetMovementDirection(Vector2 direction)
    {
        moveDirection = direction.normalized; // Нормализуем вектор направления
    }

    void Update()
    {
        // Перемещаем объект
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}

using UnityEngine;

public class DamageObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);  // Уничтожение объекта при попадании в игрока
        }

        if (other.CompareTag("borders"))
        {
            // Уничтожаем объект (DamageObject)
            Destroy(gameObject);
        }

    }
}

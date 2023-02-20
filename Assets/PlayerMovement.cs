using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forceJump = 10f;
    bool ground;
    // Вызывается до Update
    void Start()
    {
        ground = true;
    }

    // Метод Update вызывается каждый кадр
    void Update()
    {
        // gameObject - объект, который является экземпляром GameObject который на сцене и к которому прикреплен скрипт
        // transofrm - объект-компонент, который прикреплен к gameObject
        // Translate - метод, который сдвигает позицию объекта на заданную величину
        // Time.deltaTime - значение промежутка времени между двумя кадрами 
        // Debug.Log - Вывод в консоль
        // Input.GetAxis() - Метод возвращающий силу нажатия клавиши управления по оси горизонтальной - Horizontal, вертикальной - Vertical 
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10, 0, 0);
        if (Input.GetKey(KeyCode.Space) && ground){
            Debug.Log("Jump");
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0,forceJump));
            ground = false;
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        ground = true;
        Debug.Log("Enter");
    }
}

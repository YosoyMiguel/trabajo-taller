using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5;
    Rigidbody2D rb;
    public GameObject disparobala;
    public float velocidadbala;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movimiento = new Vector2(horizontal, vertical).normalized * velocidad;

        rb.velocity = movimiento;

        //Esto es para disparar:

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector2 direcciondisparo = (mousePosition - transform.position).normalized;
            GameObject bala = Instantiate(disparobala, transform.position, Quaternion.identity);
            Rigidbody2D rbbala = bala.GetComponent<Rigidbody2D>();
            rbbala.velocity = direcciondisparo * velocidadbala;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilJugador : MonoBehaviour
{
    float _vel = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;

        novaPos = novaPos + new Vector2(0f, 1f) * _vel * Time.deltaTime;

        transform.position = novaPos;

        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 1f));
        if (transform.position.y > maxPantalla.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Enemic")
        {
            Destroy(gameObject);
        }
    }
}

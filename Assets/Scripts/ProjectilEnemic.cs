using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilEnemic : MonoBehaviour
{
    private float _vel;
    private bool _continuaUltimaDireccio;
    private Vector2 _direccioJugador;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 5f;
        _continuaUltimaDireccio = false;
        _direccioJugador = Vector2.down;
        Invoke("ContinuaUltimaDireccio", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //MovimentVertical();
        if (GameObject.FindWithTag("NauJugador") != null)
        {
            if (!_continuaUltimaDireccio)
            {
                GameObject nauJugador = GameObject.FindWithTag("NauJugador");
                _direccioJugador = (nauJugador.transform.position - transform.position).normalized;
            }

            Vector2 novaPos = transform.position;
            novaPos = novaPos + _direccioJugador * _vel * Time.deltaTime;
            transform.position = novaPos;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ContinuaUltimaDireccio()
    {
        _continuaUltimaDireccio = true;
    }

    private void MovimentVertical()
    {
        Vector2 novaPos = transform.position;

        novaPos = novaPos + Vector2.down * _vel * Time.deltaTime;

        transform.position = novaPos;
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "NauJugador")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    private float _vel;

    public GameObject _ExplosioPrefab;

    public GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        
        // "Horizontal" i "Vertical" estan definits per Unity.

        //      "Horizontal" detecta quan es prem les tecles:
        //          a, d, fletxa esquerra, fletxa dreta.

        //      "Vertical" detecta quan es prem les tecles:
        //          w, s, fletxa amunt, fletxa avall.
        float direccioInputX = Input.GetAxisRaw("Horizontal");
        float direccioInputY = Input.GetAxisRaw("Vertical");
        //Debug.Log(direccioInputX + " - " + direccioInputY);

        Vector2 direccioIndicada = new Vector2(direccioInputX, direccioInputY).normalized;
        //Debug.Log(direccioIndicada + " magnitud=" + direccioIndicada.magnitude);

        MoureNau(direccioIndicada);

    }

    void MoureNau(Vector2 direccioIndicada)
    {
        // Anem a moure la nau:
        // 1) Agafem la posició actual (x, y) de la nau:
        //      transform.position ens retorna la posició actual de la nau.
        Vector2 posNau = transform.position;

        // 2) Trobem la nova posició de la nau:
        posNau = posNau + direccioIndicada * _vel * Time.deltaTime;
        //Debug.Log("Time.deltaTime=" + Time.deltaTime);

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        maxPantalla.x = maxPantalla.x - 0.6f;
        minPantalla.x = minPantalla.x + 0.6f;
        maxPantalla.y = maxPantalla.y - 0.8f;
        minPantalla.y = minPantalla.y + 0.8f;

        posNau.x = Mathf.Clamp(posNau.x, minPantalla.x, maxPantalla.x);
        posNau.y = Mathf.Clamp(posNau.y, minPantalla.y, maxPantalla.y);

        // 3) Assignem la nova posició (movem l'objecte):
        transform.position = posNau;
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Enemic")
        {
            GameObject explosio = Instantiate(_ExplosioPrefab);
            explosio.transform.position = transform.position;

            _gameManager.GetComponent<GameManager>().PassarAGameOver();

            //Destroy(gameObject);
        }
    }
}

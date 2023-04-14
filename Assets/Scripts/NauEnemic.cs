using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauEnemic : MonoBehaviour
{
    float _vel = 3f;

    public GameObject _ExplosioPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;

        Vector2 direccio = new Vector2(0f, -1f);

        novaPos = novaPos + direccio * _vel * Time.deltaTime;

        transform.position = novaPos;

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < minPantalla.y)
        {
            //Debug.Log("Ha sortit fora.");
            // GameObject és l'objecte actual que té aquest script (com si fos un "this").
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "ProjectilJugador" || objecteTocat.tag == "NauJugador")
        {

            GameObject explosio = Instantiate(_ExplosioPrefab);
            explosio.transform.position = transform.position;

            int puntsEnemic = 200;
            GameObject.Find("TextPunts").GetComponent<TextPuntsJugador>().setPuntsJugador(puntsEnemic);

            Destroy(gameObject);
        }
    }
}

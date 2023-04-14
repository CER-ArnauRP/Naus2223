using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _botoJugar;
    public GameObject _nauJugador;
    public GameObject _generadorEnemics;
    public GameObject _textPuntsJugador;

    public enum EstatsGameManager
    {
        Inici,
        Jugant,
        GameOver
    }

    private EstatsGameManager _estatGameManager;

    // Start is called before the first frame update
    void Start()
    {
        _estatGameManager = EstatsGameManager.Inici;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualitzarEstatGameManager()
    {
        switch (_estatGameManager)
        {
            case EstatsGameManager.Inici:

                _botoJugar.SetActive(true);
                _nauJugador.SetActive(false);
                _textPuntsJugador.GetComponent<TextPuntsJugador>().InicialitzarPunts();
                _textPuntsJugador.SetActive(false);

                break;

            case EstatsGameManager.Jugant:

                _botoJugar.SetActive(false);
                _nauJugador.SetActive(true);
                _textPuntsJugador.SetActive(true);
                _generadorEnemics.GetComponent<GeneradorEnemics>().IniciGeneraEnemics();

                break;

            case EstatsGameManager.GameOver:

                _botoJugar.SetActive(false);
                _nauJugador.SetActive(false);
                _textPuntsJugador.SetActive(true);
                _generadorEnemics.GetComponent<GeneradorEnemics>().AturaGenerarEnemics();

                Invoke("PassarAEstatInici", 3f);

                break;
        }
    }

    public void setEstatGameManager(EstatsGameManager estatGameManager)
    {
        _estatGameManager = estatGameManager;
        ActualitzarEstatGameManager();
    }

    public void PassarAEstatJugant()
    {
        _estatGameManager = EstatsGameManager.Jugant;
        ActualitzarEstatGameManager();
    }

    public void PassarAGameOver()
    {
        _estatGameManager = EstatsGameManager.GameOver;
        ActualitzarEstatGameManager();
    }

    public void PassarAEstatInici()
    {
        _estatGameManager = EstatsGameManager.Inici;
        ActualitzarEstatGameManager();
    }
}

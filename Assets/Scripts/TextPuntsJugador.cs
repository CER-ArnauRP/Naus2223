using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPuntsJugador : MonoBehaviour
{
    private TMPro.TextMeshProUGUI _puntsJugadorText;
    private int _puntsJugadorInt;

    // Start is called before the first frame update
    void Start()
    {
        _puntsJugadorText = GetComponent<TMPro.TextMeshProUGUI>();
        _puntsJugadorInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPuntsJugador(int nousPunts)
    {
        _puntsJugadorInt += nousPunts;
        _puntsJugadorText.text = "Punts: " + _puntsJugadorInt;
    }

    public int getPuntsJugador()
    {
        return _puntsJugadorInt;
    }

    public void InicialitzarPunts()
    {
        _puntsJugadorInt = 0;
        _puntsJugadorText.text = "Punts: 0";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorProjectilEnemic : MonoBehaviour
{
    public GameObject _ProjectilEnemicPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreaProjectil", 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreaProjectil()
    {
        if (GameObject.FindWithTag("NauJugador") != null)
        {
            GameObject projectil = Instantiate(_ProjectilEnemicPrefab);
            projectil.transform.position = transform.position;
        }
    }
}

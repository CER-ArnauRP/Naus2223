using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorProjectils : MonoBehaviour
{
    public GameObject _ProjectilPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("GeneraProjectil", 2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GeneraProjectil();
        }
    }

    private void GeneraProjectil()
    {
        GameObject projectil = Instantiate(_ProjectilPrefab);
        projectil.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}

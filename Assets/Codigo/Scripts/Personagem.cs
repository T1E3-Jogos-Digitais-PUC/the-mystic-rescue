using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    float x, y;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ItemColetavel")
        {
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
        if ((y != 0 || x != 0))
        {
            transform.Translate(x * Time.deltaTime * 10, y * Time.deltaTime * 10, 0);
        }
        
    }
}

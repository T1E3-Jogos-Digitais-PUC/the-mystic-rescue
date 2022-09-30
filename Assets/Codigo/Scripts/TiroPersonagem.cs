using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPersonagem : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Personagem"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Time.deltaTime * 5, 0);
    }
}

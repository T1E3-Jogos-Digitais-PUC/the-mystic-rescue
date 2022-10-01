using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float moveSpeed = 12f;
    
    private float vert, horiz;


    private Rect cameraRect;


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
        var bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));
        cameraRect = new Rect(bottomLeft.x, bottomLeft.y, topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

    }

    // Update is called once per frame
    void Update()
    {
        //FIXME: Consegui fazer mais ou menos... porém o deslocamento no eixo X está com uma folga a esquerda e passando a direita

        vert = Input.GetAxis("Vertical");
        horiz = Input.GetAxis("Horizontal");
        if ((vert != 0 || horiz != 0))
        {
            // transform.Translate(x * Time.deltaTime * 10, y * Time.deltaTime * 10, 0);
            transform.Translate(horiz * Time.deltaTime * moveSpeed, vert * Time.deltaTime * moveSpeed, 0);
            
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
            
            
        }

        
        
        
    }
}

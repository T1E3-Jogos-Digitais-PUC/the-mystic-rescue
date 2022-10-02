using UnityEngine;

namespace Codigo.Scripts.Entity.player
{
    public class PlayerGun: MonoBehaviour
    {
        // public KeyCode Key;
        public GameObject Prefab;
        public AudioSource FireSound;
        
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(Prefab, transform.position, transform.rotation);
                // FireSound.Play();
            }
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thing
{
    public class ThingEntity : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            isThingFine();
        }

        void isThingFine()
        {
            if (gameObject.transform.position.y < -5)
            {
                Main.MainController.Instance.GetComponent<Player.PlayerController>().lifes-=5;
                Destroy(gameObject);
            }
        }

        public void freeze()
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            
        }

        public void unfreeze()
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

namespace Boat
{
    public class BoatController : SingletonSaved<BoatController>
    {
        public float speed;
        public GameObject boat;

        void Start()
        {

        }

        void Update()
        {
            //float str = speed * Time.deltaTime;
            //// boat.transform.rotation = Quaternion.Lerp(boat.transform.rotation, Quaternion.AngleAxis(0, Vector3.up), str);
            //boat.transform.Rotate(boat.transform.rotation.eulerAngles + Vector3.right * 90);
            //Debug.Log(boat.transform.rotation);
        }
    }
}


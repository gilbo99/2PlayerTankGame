using System.Collections.Generic;
using UnityEngine;

namespace Andrew
{



    public class AbilitiesBox : MonoBehaviour
    {
        public List<GameObject> item;
        public GameObject give;

        public void Awake()
        {
            give = item[Random.Range(0, item.Count)];
        }


        public void KillMe()
        {
            Destroy(gameObject);
        }


    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerrubarPlataforma : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().useGravity = true;
            Destroy(gameObject, 0.3f);
        }
    }
}

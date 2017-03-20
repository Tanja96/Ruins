using System.Collections;
using UnityEngine;

public class FeatherScript : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //pickup
            PlayerScript.refrence.feathers += 1;
            Destroy(gameObject);
        }
    }
}

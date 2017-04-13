using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour {

    public string loadName;
    public string unloadName;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (loadName != "")
                GameController.Instance.loadScene(loadName);
            if (unloadName != "")
                StartCoroutine("UnloadScene");
        }
    }

    IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(.10f);
        GameController.Instance.unloadScene(unloadName);
    }
}

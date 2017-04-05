using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLearning : MonoBehaviour {

    private bool longJumpPanel = false;
    private bool grabPanel = false;
    private bool slidePanel = false;
    private bool glidePanel = false;
    private bool flyPanel = false;

    public Texture lJumpImg;
    public Texture grabImg;
    public Texture slideImg;
    public Texture glideImg;
    public Texture flyImg;

    // Use this for initialization
    void Start () {

        GetComponent<PlayerGrab>().enabled = false;
        GetComponent<PlayerSlide>().enabled = false;
        //GetComponent<PlayerGlide>().enabled = false;
        //GetComponent<PlayerFly>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LongJumpSkill"))
        {
            longJumpPanel = true;
            
        }
        else if (other.gameObject.CompareTag("GrabSkill"))
        {
            grabPanel = true;
            GetComponent<PlayerGrab>().enabled = true;
        }
        else if (other.gameObject.CompareTag("SlideSkill"))
        {
            slidePanel = true;
            GetComponent<PlayerSlide>().enabled = true;
        }
        //else if (other.gameObject.CompareTag("GlideSkill"))
        //{
        //    glidePanel = true;
        //    GetComponent<PlayerGlide>().enabled = true;
        //}
        //else if (other.gameObject.CompareTag("FlySkill"))
        //{
        //    flyPanel = true;
        //    GetComponent<PlayerFly>().enabled = true;
        //}
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LongJumpSkill"))
        {
            longJumpPanel = false;
        }
        else if (other.gameObject.CompareTag("GrabSkill"))
        {
            grabPanel = false;
        }
        else if (other.gameObject.CompareTag("SlideSkill"))
        {
            slidePanel = false;
        }
        else if (other.gameObject.CompareTag("GlideSkill"))
        {
            glidePanel = false;
        }
        else if (other.gameObject.CompareTag("FlySkill"))
        {
            flyPanel = false;
        }
    }

    void OnGUI()
    {
        if(longJumpPanel == true)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 165, Screen.height / 2 + 249, 330, 249), lJumpImg, ScaleMode.ScaleToFit, true, 1.0F);
        }
        else if (grabPanel == true)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 165, Screen.height / 2 + 249, 330, 249), grabImg, ScaleMode.ScaleToFit, true, 1.0F);
        }
        else if (slidePanel == true)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 165, Screen.height / 2 + 249, 330, 249), slideImg, ScaleMode.ScaleToFit, true, 1.0F);
        }
        else if (glidePanel == true)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 165, Screen.height / 2 + 249, 330, 249), glideImg, ScaleMode.ScaleToFit, true, 1.0F);
        }
        else if (flyPanel == true)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 165, Screen.height / 2 + 249, 330, 249), flyImg, ScaleMode.ScaleToFit, true, 1.0F);
        }
    }
}



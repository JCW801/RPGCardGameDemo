using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SendToAndroid()
    {
        using (AndroidJavaClass jc =new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject jo =new AndroidJavaObject("MainActivity"))
            {
                jo.Call("", "");
            }
        }
    }
}

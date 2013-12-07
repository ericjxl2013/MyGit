using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	int rlt = 0;
	
	
	// Use this for initialization
	void Start () {
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		rlt = jo.Call<int>("Max", new object[] {10, 20});
		Debug.Log(rlt);
	}
	
	
	void OnGUI () {
		GUILayout.Label(rlt.ToString());
		if(GUILayout.Button("Shake")){
			using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
				using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity")){
					jo.Call("Shake", 1000);
				}
			}
		}
		if(GUILayout.Button("CancleShake")){
			 AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jo.Call("CancleShake");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

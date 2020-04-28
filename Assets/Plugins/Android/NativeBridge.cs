using UnityEngine;

#if UNITY_ANDROID
public class NativeBridge
{

    private const string key = "naren";
    //method that calls our native plugin.
    public static void SaveData(string value)
    {
        // Retrieve the UnityPlayer class.
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Retrieve the UnityPlayerActivity object ( a.k.a. the current context )
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        // Retrieve the "Bridge" from our native plugin.
        // ! Notice we define the complete package name.              
        AndroidJavaObject bridge = new AndroidJavaObject("com.naren.sharedsdk.ShareData");

        // Setup the parameters we want to send to our native plugin.              
        object[] parameters = new object[3];
        parameters[0] = unityActivity;
        parameters[1] = key;
        parameters[2] = value;

        // Call set prefrence string in bridge, with our parameters.
        bridge.Call("setPreferenceString", parameters);
    }

    public static string RetreiveData()
    {
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Retrieve the UnityPlayerActivity object ( a.k.a. the current context )
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        // Retrieve the "Bridge" from our native plugin.
        // ! Notice we define the complete package name.              
        AndroidJavaObject bridge = new AndroidJavaObject("com.naren.sharedsdk.ShareData");

        // Setup the parameters we want to send to our native plugin.              
        object[] parameters = new object[2];
        parameters[0] = unityActivity;
        parameters[1] = key;

        // Call PrintString in bridge, with our parameters.
        return bridge.Call<string>("getPreferenceString", parameters);
    }
}
#endif

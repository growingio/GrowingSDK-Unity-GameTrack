using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GrowingIOGame {
#if UNITY_ANDROID

        private static string ANDROID_CLASS = "com.growingio.android.plugin.game.GrowingIOGame";
        private static AndroidJavaObject dicToMap(Dictionary<string, string> dictionary) {
        if (dictionary == null) {
            return null;
        }

        AndroidJavaObject map = new AndroidJavaObject("java.util.HashMap");
        foreach (KeyValuePair<string, string> pair in dictionary) {
            map.Call<string>("put", pair.Key, pair.Value);
        }

        return map;
    }

#endif

#if UNITY_IPHONE

        /* Interface to native implementation */

    [DllImport("__Internal")]
    private static extern void gioTrack(string eventId);

    [DllImport("__Internal")]
    private static extern void gioTrackWithNumber(string eventId, double number);

    [DllImport("__Internal")]
    private static extern void gioTrackWithNumberAndVariable(string eventId, double number, string[] keys, string[] stringValues, int count);

    [DllImport("__Internal")]
    private static extern void gioTrackWithVariable(string eventId, string[] keys, string[] stringValues, int count);

    [DllImport("__Internal")]
    private static extern void gioSetEvar(string[] keys, string[] stringValues, int count);

    [DllImport("__Internal")]
    private static extern void gioSetEvarWithKeyAndString(string key, string stringValue);

    [DllImport("__Internal")]
    private static extern void gioSetEvarWithKeyAndNumber(string key, double number);

    [DllImport("__Internal")]
    private static extern void gioSetPeople(string[] keys, string[] stringValues, int count);

    [DllImport("__Internal")]
    private static extern void gioSetPeopleWithKeyAndString(string key, string stringValue);

    [DllImport("__Internal")]
    private static extern void gioSetPeopleWithKeyAndNumber(string key, double number);

    [DllImport("__Internal")]
    private static extern void gioSetVistor(string[] keys, string[] stringValues, int count);

    [DllImport("__Internal")]
    private static extern void gioSetUserId(string userId);

    [DllImport("__Internal")]
    private static extern void gioClearUserId();

#endif 

    public static void Track(string eventId) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
            #if UNITY_IPHONE
                gioTrack(eventId);
            #endif
            #if UNITY_ANDROID
                new AndroidJavaClass(ANDROID_CLASS).CallStatic("track", eventId);
            #endif
        } 

    }

    public static void Track(string eventId, double number) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            gioTrackWithNumber(eventId, number);
        #endif
        #if UNITY_ANDROID
             new AndroidJavaClass(ANDROID_CLASS).CallStatic("track", eventId, number);
        #endif
        }

    }

    public static void Track(string eventId, Dictionary<string, string> variable) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            if (variable != null && variable.Count > 0) {
                int count = variable.Count;
                string[] keys = new string[count];
                string[] stringValues = new string[count];
                int index = 0;
                foreach (KeyValuePair<string, string> kvp in variable) {
                    keys[index] = kvp.Key;
                    stringValues[index] = (string)kvp.Value;
                    index++;
                }
                gioTrackWithVariable(eventId, keys, stringValues, count);
            } else {
                gioTrack(eventId);
            }
        #endif
        #if UNITY_ANDROID
            new AndroidJavaClass(ANDROID_CLASS).CallStatic("track", eventId, dicToMap(variable));
        #endif
        }

    }

    public static void Track(string eventId, double number, Dictionary<string, string> variable) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            if (variable != null && variable.Count > 0) {
                int count = variable.Count;
                string[] keys = new string[count];
                string[] stringValues = new string[count];
                int index = 0;
                foreach (KeyValuePair<string, string> kvp in variable) {
                    keys[index] = kvp.Key;
                    stringValues[index] = (string)kvp.Value;
                    index++;
                }
                gioTrackWithNumberAndVariable(eventId, number, keys, stringValues, count);
            } else {
                gioTrackWithNumber(eventId, number);
            }
        #endif
        #if UNITY_ANDROID
            new AndroidJavaClass(ANDROID_CLASS).CallStatic("track", eventId, number, dicToMap(variable));
        #endif
        }
          
    }

    public static void SetEvar(string key, string value) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
             gioSetEvarWithKeyAndString(key, value);
        #endif
        #if UNITY_ANDROID
             new AndroidJavaClass(ANDROID_CLASS).CallStatic("setEvar", key, value);
        #endif
        }

    }

    public static void SetEvar(string key, double number) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            gioSetEvarWithKeyAndNumber(key, number);
        #endif
        #if UNITY_ANDROID
           new AndroidJavaClass(ANDROID_CLASS).CallStatic("setEvar", key, number);
        #endif
        }
        
    }

    public static void SetEvar(Dictionary<string, string> variable) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            if (variable != null && variable.Count > 0) {
                int count = variable.Count;
                string[] keys = new string[count];
                string[] stringValues = new string[count];
                int index = 0;
                foreach (KeyValuePair<string, string> kvp in variable) {
                    keys[index] = kvp.Key;
                    stringValues[index] = (string)kvp.Value;
                    index++;
                }
                gioSetEvar(keys, stringValues, count);
            }
        #endif
        #if UNITY_ANDROID
             new AndroidJavaClass(ANDROID_CLASS).CallStatic("setEvar", dicToMap(variable));
        #endif
        }
        
    }

    public static void SetPeopleVariable(string key, string value) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            gioSetPeopleWithKeyAndString(key, value);
        #endif
        #if UNITY_ANDROID
            new AndroidJavaClass(ANDROID_CLASS).CallStatic("setPeopleVariable", key, value);
        #endif
        }

    }

    public static void SetPeopleVariable(string key, double number) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            gioSetPeopleWithKeyAndNumber(key, number);
        #endif
        #if UNITY_ANDROID
            new AndroidJavaClass(ANDROID_CLASS).CallStatic("setPeopleVariable", key, number);
        #endif
        }
        
    }

    public static void SetPeopleVariable(Dictionary<string, string> variable) {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            if (variable != null && variable.Count > 0) {
                int count = variable.Count;
                string[] keys = new string[count];
                string[] stringValues = new string[count];
                int index = 0;
                foreach (KeyValuePair<string, string> kvp in variable) {
                    keys[index] = kvp.Key;
                    stringValues[index] = (string)kvp.Value;
                    index++;
                }
                 gioSetPeople(keys, stringValues, count);
            }
        #endif
        #if UNITY_ANDROID
            new AndroidJavaClass(ANDROID_CLASS).CallStatic("setPeopleVariable", dicToMap(variable));
        #endif
        }
        
    }

    public static void SetVisitor(Dictionary<string, string> variable) {

        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            if (variable != null && variable.Count > 0) {
                int count = variable.Count;
                string[] keys = new string[count];
                string[] stringValues = new string[count];
                int index = 0;
                foreach (KeyValuePair<string, string> kvp in variable) {
                    keys[index] = kvp.Key;
                    stringValues[index] = (string)kvp.Value;
                    index++;
                }
                gioSetVistor(keys, stringValues, count);
            }
        #endif
        #if UNITY_ANDROID
            new AndroidJavaClass(ANDROID_CLASS).CallStatic("setVisitor", dicToMap(variable));
        #endif
        }

    }

    public static void SetUserId(string userId) {
         if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            gioSetUserId(userId);
        #endif
        #if UNITY_ANDROID
            new AndroidJavaClass(ANDROID_CLASS).CallStatic("setUserId", userId);
        #endif
        }
        
    }

    public static void ClearUserId() {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor) {
        #if UNITY_IPHONE
            gioClearUserId();
        #endif
        #if UNITY_ANDROID
             new AndroidJavaClass(ANDROID_CLASS).CallStatic("clearUserId");
        #endif
        }       
    }
}
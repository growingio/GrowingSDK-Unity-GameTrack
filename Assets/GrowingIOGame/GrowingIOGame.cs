using System.Collections.Generic;
using UnityEngine;

public class GrowingIOGame {
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

    public static void Start(string projectId, string urlScheme) {
        AndroidJavaObject context = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass jc = new AndroidJavaClass(ANDROID_CLASS);
        jc.CallStatic("start", context, projectId, urlScheme);
    }

    public static void Track(string eventId) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("track", eventId);
    }

    public static void Track(string eventId, double number) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("track", eventId, number);
    }

    public static void Track(string eventId, Dictionary<string, string> variable) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("track", eventId, dicToMap(variable));
    }

    public static void Track(string eventId, double number, Dictionary<string, string> variable) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("track", eventId, number, dicToMap(variable));
    }

    public static void SetEvar(string key, string value) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("setEvar", key, value);
    }

    public static void SetEvar(string key, double number) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("setEvar", key, number);
    }

    public static void SetEvar(Dictionary<string, string> variable) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("setEvar", dicToMap(variable));
    }

    public static void SetPeopleVariable(string key, string value) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("setPeopleVariable", key, value);
    }

    public static void SetPeopleVariable(string key, double number) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("setPeopleVariable", key, number);
    }

    public static void SetPeopleVariable(Dictionary<string, string> variable) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("setPeopleVariable", dicToMap(variable));
    }

    public static void SetVisitor(Dictionary<string, string> variable) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("setVisitor", dicToMap(variable));
    }

    public static void SetUserId(string userId) {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("setUserId", userId);
    }

    public static void ClearUserId() {
        new AndroidJavaClass(ANDROID_CLASS).CallStatic("clearUserId");
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }


    void OnGUI() {
        GUI.skin.button.fontSize = 45;
        float buttonWidth = Screen.width / 2 - 5;
        float buttonHeight = Screen.height / 10;

        float leftX = 0;
        float rightX = buttonWidth + 10;

        float y = 10;

        if (GUI.Button(new Rect(leftX, y, buttonWidth, buttonHeight), "Track String")) {
            GrowingIOGame.Track("StringTrack");
        }

        if (GUI.Button(new Rect(rightX, y, buttonWidth, buttonHeight), "Track Number")) {
            GrowingIOGame.Track("NumberTrack", 10);
        }

        y = y + buttonHeight + 10;
        if (GUI.Button(new Rect(leftX, y, buttonWidth, buttonHeight), "Track Dictionary")) {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};
            GrowingIOGame.Track("DictionaryTrack", dictionary);
        }

        if (GUI.Button(new Rect(rightX, y, buttonWidth, buttonHeight), "Track Number Dictionary")) {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};
            GrowingIOGame.Track("NumberDictionaryTrack", 66.66, dictionary);
        }

        y = y + buttonHeight + 10;
        if (GUI.Button(new Rect(leftX, y, buttonWidth, buttonHeight), "Set Evar String")) {
            GrowingIOGame.SetEvar("EvarStringKey", "EvarString");
        }

        if (GUI.Button(new Rect(rightX, y, buttonWidth, buttonHeight), "Set Evar Number")) {
            GrowingIOGame.SetEvar("EvarNumberKey", "100");
        }

        y = y + buttonHeight + 10;
        if (GUI.Button(new Rect(leftX, y, buttonWidth, buttonHeight), "Set Evar Dictionary")) {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"EvarKey1", "EvarValue1"}, {"EvarKey2", "EvarValue2"}};
            GrowingIOGame.SetEvar(dictionary);
        }

        if (GUI.Button(new Rect(rightX, y, buttonWidth, buttonHeight), "Set People String")) {
            GrowingIOGame.SetPeopleVariable("PeopleStringKey", "PeopleString");
        }

        y = y + buttonHeight + 10;
        if (GUI.Button(new Rect(leftX, y, buttonWidth, buttonHeight), "Set People Number")) {
            GrowingIOGame.SetPeopleVariable("PeopleNumberKey", "PeopleNumber");
        }

        if (GUI.Button(new Rect(rightX, y, buttonWidth, buttonHeight), "Set People Dictionary")) {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"PeopleKey1", "PeopleValue1"}, {"PeopleKey2", "PeopleValue2"}};
            GrowingIOGame.SetPeopleVariable(dictionary);
        }

        y = y + buttonHeight + 10;
        if (GUI.Button(new Rect(leftX, y, buttonWidth, buttonHeight), "Set Visitor Dictionary")) {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"VisitorKey1", "VisitorValue1"}, {"VisitorKey2", "VisitorValue2"}};
            GrowingIOGame.SetVisitor(dictionary);
        }

        if (GUI.Button(new Rect(rightX, y, buttonWidth, buttonHeight), "Set User Id")) {
            GrowingIOGame.SetUserId("张三");
        }

        y = y + buttonHeight + 10;
        if (GUI.Button(new Rect(leftX, y, buttonWidth, buttonHeight), "Clear User Id")) {
            GrowingIOGame.ClearUserId();
        }
    }
}
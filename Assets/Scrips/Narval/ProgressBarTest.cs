using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarTest : MonoBehaviour {
    float barDisplay = 0;
    Vector2 pos = new Vector2(20,40);
    Vector2 size = new Vector2(60,20);
    Texture2D progressBarEmpty;
    Texture2D progressBarFull;
    float counter = 0;
    float ticks;
    bool running;

public void initiate(float time) {
        barDisplay = 0f;
        ticks = 1f / time;
    }

void OnGUI() {
        // draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);

        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.EndGroup();

        GUI.EndGroup();

    }

void Update() {
        //barDisplay = Time.time * 1f;
        barDisplay = counter * ticks;
        counter++;
    }

}

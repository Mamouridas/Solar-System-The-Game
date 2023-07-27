using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score = 0;
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable
    private string scoreValue = "Score: ";
    private string comment;
    public float x = 10;
    public float y = 10;

    void OnGUI()
    {
        guiStyle.fontSize = 30;
        guiStyle.normal.textColor = Color.white;

        if (gameObject.GetComponent<MeteroGenerate>().destroyedPlanets == 5)
        {
            if (score <= 200) comment = "                      Are you even trying?";
            else if (score > 200 && score <= 500) comment = "                  I know you can do better...";
            else if (score > 500 && score <= 1000) comment = "          That's pretty average but well done!";
            else if (score > 1000 && score <= 1600) comment = "          You had some nice shots good job!";
            else if (score > 1600 && score < 2500) comment = "                 WOW! Great shots buddy!";
            else if (score == 2500) comment = "All in one? You achieved the impossible score!";
            guiStyle.fontSize = 50;
            GUI.Label(new Rect(Screen.width/2 - 180, Screen.height/2 - 155, 100, 100), "      YOU WON!\n\n  Final Score: " + score, guiStyle);
            GUI.Label(new Rect(Screen.width / 2 - 500, Screen.height / 2 + 80, 100, 100), comment, guiStyle);
        }
        else
        {
            GUI.Label(new Rect(x, y, 100, 100), scoreValue + score, guiStyle);
        }
    }
}
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;
    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerState.Lives.ToString() + " Lives";
    }
}

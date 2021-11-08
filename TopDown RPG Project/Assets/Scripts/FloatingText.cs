using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active;
    public GameObject gameobject;
    public Text text;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        gameobject.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        gameobject.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        if (!active)
        {
            return;
        }

        if (Time.time - lastShown > duration)
        {
            Hide();
        }

        gameobject.transform.position += motion * Time.deltaTime;
    }
}

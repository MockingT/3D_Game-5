﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskData : MonoBehaviour, OnReachEndCallback
{
    private float time;
    public float g = -9.8f; // gravity speed
    public Vector3 pointA; // start from point a
    public Vector3 pointB; // end at point b
    public Vector3 _speed; // moving speed
    public Vector3 Gravity; 
    public Vector3 currentAngle; // the angle
    public float dTime = 0;
    public float shotSpeed; // launching speed
    public int indexInUsed { get; set; }
    public int shotScore { get; set; }
    public int innerDiskCount { get; set; }
    public int timeCount;
    public int currentTimeCount;
    public bool isEnabled { get; set; } // whether it can move
    public ActionManager am;
    public bool reachedEnd // whether reached
    {
        get
        {
            if (currentTimeCount >= timeCount)
                return true;
            return false;
        }
    }

    // set the random start and end point
    public static Vector3 getRandomStartPoint()
    {
        Vector3 random = new Vector3(Random.Range(-1.5f, 1.5f), 1.5f, -12f);
        return random;
    }
    public static Vector3 getRandomEndPoint()
    {
        Vector3 random = new Vector3(Random.Range(-5f, 5f), Random.Range(3f, 8f), 5f);
        return random;
    }
    // set random color
    public static Color getRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color tcolor = new Color(r, g, b);
        return tcolor;
    }

    public void ReachEndCallback(DiskData disk)
    {
        Singleton<DiskFactory>.Instance.FreeDisk(disk);
    }

    // set the shape and the color
    public void setShapeColor(int ruler)
    {
        Renderer render = this.transform.GetComponent<Renderer>();
        render.material.shader = Shader.Find("Transparent/Diffuse");
        render.material.color = getRandomColor();
        this.transform.localScale = new Vector3(2 - 0.1f * ruler, 2 - 0.1f * ruler, 2 - 0.1f * ruler);
    }

    // Initialize: set the start location and the shape, color
    public void setStart(int a)
    {
        setShapeColor(a);
        timeCount = (int)(2f / Time.deltaTime);
        currentTimeCount = 0;
        this.isEnabled = true;
        this.shotScore = 10 * a; // in round1, 10points per hit, round2, 20points per hit...
        shotSpeed = 20f + 10f * a;
        pointA = getRandomStartPoint();
        pointB = getRandomEndPoint();
        time = Vector3.Distance(pointA, pointB) / shotSpeed;
        transform.position = pointA;
        _speed = new Vector3((pointB.x - pointA.x) / time,
            (pointB.y - pointA.y) / time - 0.5f * g * time, (pointB.z - pointA.z) / time);
        Gravity = Vector3.zero;
    }

    public void reset()
    {
        isEnabled = false;
        this.transform.position = pointA;
        _speed = Vector3.zero;
        Gravity = Vector3.zero;
        currentAngle = Vector3.zero;
        this.transform.eulerAngles = currentAngle;
        currentTimeCount = 0;
        dTime = 0;
    }

    void FixedUpdate()
    {
        am = Singleton<ActionManager>.Instance;
        am.fixedUpdate(this);
    }
}

public interface OnReachEndCallback
{
    void ReachEndCallback(DiskData disk);
}
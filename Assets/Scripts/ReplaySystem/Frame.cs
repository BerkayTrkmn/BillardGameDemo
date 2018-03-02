using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame  {

    Vector3 position;
    Vector3 scale;
    Quaternion rotation;
    GameObject gameObject;

    public Frame(GameObject go, Vector3 _position , Quaternion _rotation , Vector3 _scale)
    {
        position = _position;
        rotation = _rotation;
        scale = _scale;
        gameObject = go;


    }

    public Vector3 Position
    {
        get
        {
            return position;
        }
    }

    public Quaternion Rotation
    {
        get
        {
            return rotation;
        }
    }

    public Vector3 Scale
    {
        get
        {
            return scale;
        }
    }

    public GameObject GameObject
    {
        get
        {
            return gameObject;
        }
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class PlayerUnitProperty : MonoBehaviour
{

    public string action;
    public float hp;
    public int color;

    float time;

    // Use this for initialization
    void Start()
    {
        time = 0;
        action = "idle";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.1)
        {
            UpdatePosition();
            time = 0;
        }
    }

    void UpdatePosition()
    {
        Firebase.Auth.FirebaseUser user = Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser;
        UnitInfo info = new UnitInfo(transform.position.x, transform.position.z, transform.rotation.y,hp, user.UserId, user.DisplayName, action, color);
        FirebaseDatabase.DefaultInstance.GetReference("units").Child(user.UserId).SetRawJsonValueAsync(JsonUtility.ToJson(info));
    }

    void OnApplicationQuit()
    {
        Firebase.Auth.FirebaseUser user = Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser;
        FirebaseDatabase.DefaultInstance.GetReference("units").Child(user.UserId).RemoveValueAsync();
    }
}

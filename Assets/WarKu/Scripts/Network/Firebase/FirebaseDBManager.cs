using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
public class FirebaseDBManager : MonoBehaviour {

    Dictionary<string, OtherUnitProperty> others;
    public GameObject otherPrefabs;

    void Awake()
    {
        others = new Dictionary<string, OtherUnitProperty>();
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://warku3d.firebaseio.com/");
        FirebaseDatabase.DefaultInstance.GetReference("units")
            .ChildChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ChildChangedEventArgs args)
    {
        UnitInfo info = JsonUtility.FromJson<UnitInfo>(args.Snapshot.GetRawJsonValue());
        bool isOwner = info.uid == Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        if (others.ContainsKey(info.uid) && !isOwner)
        {
            others[info.uid].UpdatePosition(info.x, info.y, info.r, info.action);
        }
        else if (!others.ContainsKey(info.uid) && !isOwner)
        {
            GameObject other = Instantiate(otherPrefabs, new Vector3(info.x, 0, info.y), Quaternion.identity);
            other.GetComponentInChildren<SkinnedMeshRenderer>().material.mainTexture = GameObject.FindObjectOfType<Property>().colors[info.color - 1];
            other.GetComponent<OtherUnitProperty>().uid = info.uid;
            other.GetComponent<OtherUnitProperty>().name = info.name;
            others.Add(info.uid, other.GetComponent<OtherUnitProperty>());
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        var unitRef = FirebaseDatabase.DefaultInstance.GetReference("units");
        unitRef.ChildChanged += HandleValueChanged;
        var deadRef = FirebaseDatabase.DefaultInstance.GetReference("deadlist");
        deadRef.ChildAdded += HandleDead;
    }

    void HandleDead(object sender, ChildChangedEventArgs args) {
        Debug.Log("AA");
        //UID uid = JsonUtility.FromJson<UID>(args.Snapshot.GetRawJsonValue());
        Debug.Log(args.Snapshot.Key);

        bool isOwner = args.Snapshot.Key == Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        if (isOwner)
        {
            Debug.Log("You Die");
            GameObject.FindObjectOfType<walking>().anim.Play("death");
            GameObject.FindObjectOfType<walking>().enabled = false;
            GameObject.FindObjectOfType<Property>().WorldCam.gameObject.SetActive(true);
            GameObject.FindObjectOfType<Property>().playerCam.gameObject.SetActive(false);
            GameObject.FindObjectOfType<Property>().cf2.SetActive(false);
            GameObject.FindObjectOfType<Property>().mainui.SetActive(true);
            GameObject.FindObjectOfType<Property>().die.SetActive(true);
            GameObject.FindObjectOfType<PlayerUnitProperty>().enabled = false;
            Destroy(GameObject.FindObjectOfType<walking>().gameObject, 2);
        }
        else
        {
            others[args.Snapshot.Key].GetComponent<OtherUnitProperty>().ForceDead();
            others[args.Snapshot.Key].GetComponent<OtherUnitProperty>().enabled = false;
            Destroy(others[args.Snapshot.Key].gameObject, 2);
        }
    }

    void HandleValueChanged(object sender, ChildChangedEventArgs args)
    {
        Debug.Log(args.Snapshot.GetRawJsonValue());
        UnitInfo info = JsonUtility.FromJson<UnitInfo>(args.Snapshot.GetRawJsonValue());
        bool isOwner = info.uid == Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        if (isOwner)
        {
            bool dead = FindObjectOfType<PlayerUnitProperty>().hp != info.hp;
            if (dead)
            {
                GameObject.FindObjectOfType<walking>().deathAction();
            }
        }
        if (others.ContainsKey(info.uid) && !isOwner)
        {
            others[info.uid].UpdatePosition(info.x, info.y, info.r, info.action);
            others[info.uid].hp = info.hp;
        }
        else if (!others.ContainsKey(info.uid) && !isOwner)
        {
            GameObject other = Instantiate(otherPrefabs, new Vector3(info.x, 0, info.y), Quaternion.identity);
            other.GetComponentInChildren<SkinnedMeshRenderer>().material.mainTexture = GameObject.FindObjectOfType<Property>().colors[info.color - 1];
            other.GetComponent<OtherUnitProperty>().uid = info.uid;
            other.GetComponentInChildren<TextMesh>().text = info.name;
            other.GetComponentInChildren<Image>().rectTransform.sizeDelta = new Vector2(3 * info.hp / 10f, 0.5f);
            other.GetComponentsInChildren<LookUpToCamera>()[0].camera = GameObject.FindObjectOfType<Property>().playerCam.transform;
            other.GetComponentsInChildren<LookUpToCamera>()[1].camera = GameObject.FindObjectOfType<Property>().playerCam.transform;
            other.GetComponent<OtherUnitProperty>().hp = info.hp;

            other.GetComponent<OtherUnitProperty>().name = info.name;
            others.Add(info.uid, other.GetComponent<OtherUnitProperty>());
        }
    }

    void HandleRemove(object sender, ChildChangedEventArgs args)
    {
        GameObject obj = others[args.Snapshot.Key].gameObject;
        others.Remove(args.Snapshot.Key);
        Destroy(obj);
    }
    class UID
    {
        public string uid;
        public UID(string uid)
        {
            this.uid = uid;
        }
    }
}

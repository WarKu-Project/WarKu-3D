using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class FirebaseDB : MonoBehaviour {

    public GameObject[] unitPrefabs;

    Dictionary<string, GameObject> onlineUnits;

	// Use this for initialization
	void Awake () {
        onlineUnits = new Dictionary<string, GameObject>();
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://warku3d.firebaseio.com/");
        FirebaseDatabase.DefaultInstance.GetReference("units")
            .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        
        foreach (DataSnapshot d in args.Snapshot.Children)
        {
            UnitInfo u = JsonUtility.FromJson<UnitInfo>(d.GetRawJsonValue());

            if (onlineUnits.ContainsKey(u.name))
            {
                Debug.Log(u.name);

                onlineUnits[u.name].GetComponent<Unit>().Move(u.x, u.y, u.r);
            }else
            {
                GameObject unit = Instantiate(unitPrefabs[u.type], new Vector3(u.x, 0, u.y), Quaternion.identity);
                onlineUnits.Add(u.name,unit);
            }
        }
    }

}

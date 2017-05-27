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
        FirebaseDatabase.DefaultInstance.GetReference("Leaders").OrderByChild("score")
            .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        List<UnitInfo> units = JsonUtility.FromJson<List<UnitInfo>>(args.Snapshot.GetRawJsonValue());

        foreach (UnitInfo u in units)
        {
            if (onlineUnits.ContainsKey(u.name))
            {
                onlineUnits[u.name].GetComponent<Unit>().Move(u.x, u.y, u.r);
            }else
            {
                GameObject unit = Instantiate(unitPrefabs[u.type], new Vector3(u.x, 0, u.y), Quaternion.identity);
                onlineUnits.Add(u.name,unit);
            }
        }
    }

}

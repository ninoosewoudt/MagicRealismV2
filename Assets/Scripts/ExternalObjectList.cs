using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ExternalObjectList : MonoBehaviour {

	[SerializeField]
	private string _path;

	public Dictionary<string, List<GameObject>> GameObjects;

	[SerializeField]
	private GameObject _prefab;
	[SerializeField]
	private Material _basicMaterial;

	void Start () {
		if (_path == null) {
			Debug.LogError ("not external object folder found");
		}
		GameObjects = new Dictionary<string, List<GameObject>> ();
		foreach (var fileindir in Directory.GetFiles (_path, "*.*", SearchOption.AllDirectories)) {
			var file = fileindir.Substring(_path.Length);
			//print (file);
			Mesh mesh = new ObjImporter ().ImportFile (fileindir);
			if(file.Contains("\\")){
				var dir = file.Split('\\')[0];
				var name = file.Split('\\')[1];
				if(GameObjects.ContainsKey(dir)){
					GameObjects[dir].Add(GenObject(name, mesh));
				} else {
					GameObjects.Add(dir, new List<GameObject>());
					GameObjects[dir].Add(GenObject(name, mesh));
				}
			} else {
				var name = file;
				if(GameObjects.ContainsKey("undifined")){
					GameObjects["undifined"].Add(GenObject(name, mesh));
				} else {
					GameObjects.Add("undifined", new List<GameObject>());
					GameObjects["undifined"].Add(GenObject(name, mesh));
				}
			}
			//print ("done");
		}

		Instantiate(GameObjects["test"][0]);
	}

	private GameObject GenObject(string name, Mesh mesh){
		var go = Instantiate (_prefab, new Vector3(0,1000,0), Quaternion.identity);
		go.transform.name = name;
		go.GetComponent<MeshFilter> ().mesh = mesh;
		go.GetComponent<MeshRenderer> ().material = _basicMaterial;
		var coll = go.AddComponent<MeshCollider> ();
		coll.convex = true;
		Destroy (go);
		return go;
	}
}

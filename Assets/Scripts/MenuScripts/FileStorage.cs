using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public abstract class FileStorage {
	public string PATH;

	public FileStorage(string path) {
		this.PATH = path;
	}

}
	
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Save
{
    public static void SavePlayerData(PlayerManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter(); // calls upon the ability to format variables to binary
        string path = Application.persistentDataPath + "/i.png"; // sets path to save
        FileStream stream = new FileStream(path, FileMode.Create); // creates the file at specified path via stream
        DataToSave data = new DataToSave(player); // calls upon DataToSave for player info
        formatter.Serialize(stream, data); //Serializes the data and location
        stream.Close(); // Closes the stream
    }
    public static DataToSave LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/i.png";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataToSave data = formatter.Deserialize(stream) as DataToSave;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Couldn't find file to load");
            return null;
        }
    }
}

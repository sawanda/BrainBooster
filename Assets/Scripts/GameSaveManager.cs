using System.Linq;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class GameSaveManager
{
    public static GameSave ActiveSave { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void RecallPlayer()
    {
        // for(int i = 0; i < 10 ; i++)
        // {
        //     var gs = new GameSave("TestPlayer " + i);
        //     SaveToDevice(gs);
        // }
        string whoWasActive = PlayerPrefs.GetString("ActiveLastTime");
        if (whoWasActive != "")
        {
            GameSaveManager.SetNameAsActive(whoWasActive);
        }
    }

    public static string[] AllPlayerNames
    {
        get
        {
            GameSave[] allSaves = ReadAllSaves();
            return allSaves.Select( x => x.name).ToArray();
        }
    }

    public static void SetNameAsActive(string nameToActive) 
    {
        GameSave wantToActive = ReadSaveByPlayerName(nameToActive);
        ActiveSave = wantToActive;

        //remember
        PlayerPrefs.SetString("ActiveLastTime", nameToActive);
    }

    private static GameSave ReadSaveByPlayerName(string playerName)
    {
        using (FileStream fileStream = new FileStream(Application.persistentDataPath + "/" + playerName + ".bb", FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            object gameSave = bf.Deserialize(fileStream);
            GameSave castedGameSave = (GameSave) gameSave;
            return castedGameSave;
        }
    }

    public static GameSave[] ReadAllSaves()
    {
        string[] myFiles = Directory.GetFiles(Application.persistentDataPath, "*.*", SearchOption.TopDirectoryOnly)
            .Where(s => Path.GetExtension(s) == ".bb").ToArray();

        string[] onlyPlayerNames = myFiles.Select(x => Path.GetFileNameWithoutExtension(x)).ToArray();

        GameSave[] allSaves = onlyPlayerNames.Select( x => ReadSaveByPlayerName(x)).ToArray();
        return allSaves;
    }

    public static void DeleteSaveFile(GameSave gameSave)
    {
        File.Delete(Application.persistentDataPath + "/" + gameSave.name + ".bb");
    }

    public static void SaveToDevice(GameSave gameSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log("Writing file to " + Application.persistentDataPath);

        using (FileStream fileStream = new FileStream(Application.persistentDataPath + "/" + gameSave.name + ".bb", FileMode.OpenOrCreate))
        {
            bf.Serialize(fileStream, gameSave);
        }
    }
}

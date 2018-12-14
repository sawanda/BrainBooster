
using UnityEngine;

public class PlayerPrefManager
{

    public const string keyNames = "names";
    public const string keyActiveName = "activeName";

    public static string[] AllPlayerNames()
    {
        string allPlayersString = PlayerPrefs.GetString(keyNames, "");
        string[] allPlayersArray = allPlayersString.Split(',');
        return allPlayersArray;
    }
}
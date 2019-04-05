using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;


public class UserService : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    // Start is called before the first frame update
    void Start()
    {
       print("UserService start");
    //    register();
    }

    // Update is called once per frame
    void Update()
    {
    //   print("UserService update");
    }

    public  async static void login() {
        var jsonString = await client.GetStringAsync("https://randomuser.me/api/");
        print(jsonString);

          string jsonString2 = "{\"playerId\":\"8484239823\",\"playerLoc\":\"Powai\",\"playerNick\":\"Random Nick\"}";
          Player player = (Player)JsonUtility.FromJson(jsonString2, typeof(Player));
          Debug.Log(player.playerLoc);
          
    }

     public  async static void register(string name,string age,string gender,string password) {

        var url = "https://backoffice-thesis.herokuapp.com/add?name="+name+"&age="+age+"&gender="+gender+"&password="+password;
        var jsonString = await client.GetStringAsync(url);

        print(jsonString);
    
          
    }
}

public class Results{
    public User [] results {get;set;}
}


public class User
{
    public string gender {get;set;}
    public string name {get;set;}
    public string password {get;set;}
}

public class Player
{

    public string playerId;
    public string playerLoc;
    public string playerNick;
}
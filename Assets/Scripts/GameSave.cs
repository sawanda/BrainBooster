
using System;

public enum IconType
{
    Bear = 0,
    Panda = 1,
    Rabbit = 2,
}

public enum Proficiency
{
    Unknown,
    LeftBrained,
    RightBrained,
    AllAround,
}

[Serializable]
public class GameSave
{
    public string name;
    public IconType iconType;

    public int countingLevel; //left
    public int colorsLevel; //right
    public int shapesLevel; //right
    public int analysisLevel; //left

    public int game1Score;
    public int game2Score;
    public int game3Score;
    public int game4Score;
    public int game5Score;

    public DateTime startPlayingTime;

    public GameSave(string newName)
    {
        this.name = newName;
        this.startPlayingTime = DateTime.Now;
        iconType = (IconType)UnityEngine.Random.Range(0, 3);
    }

    // public int LeftPercent
    // {
    //     get
    //     {
    //     }
    // }

    // public Proficiency Proficiency
    // {
    //     get
    //     {
            // int[] allInts = new int[]{ countingLevel, colorsLevel, shapesLevel, analysisLevel };
            // int maxInt = allInts.Max();

            // bool isLeft = false;
            // bool isRight = false;

            // if (maxInt == countingLevel)
            // {
            //     isLeft = true;
            // }
            // if (maxInt == colorsLevel)
            // {
            //     isRight = true;
            // }
            // if (maxInt == shapesLevel)
            // {
            //     isRight = true;
            // }
            // if (maxInt == analysisLevel)
            // {
            //     isLeft = true;
            // }

            // if(isLeft && !isRight) return Proficiency.LeftBrained;
            // if(!isLeft && isRight) return Proficiency.RightBrained;
            // if(isLeft && isRight) return Proficiency.AllAround;
    //     }
    // }

}
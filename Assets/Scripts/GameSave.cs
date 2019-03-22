
using System;

public enum IconType
{
    Bear = 0,
    Panda = 1,
    Rabbit = 2,
}

[Serializable]
public class GameSave
{
    public string name;
    public int age;
    public Sex sex;

    public IconType iconType;

    public int countingLevel; //left
    public int colorsLevel; //right
    public int shapesLevel; //right
    public int analysisLevel; //left

    [Serializable]
    public struct ScorePair
    {
        public int first;
        public int latest;
        public int playCount;
        private bool played;

        public void RecordScore(int score)
        {
            playCount++;
            if (played == false)
            {
                first = score;
                played = true;
            }
            else
            {
                latest = score;
            }
        }

        public float Result
        {
            get
            {
                if (playCount == 0) return 0;
                return (first + latest) / ((float)playCount);
            }
        }

        public override string ToString()
        {
            return $"ScorePair : {first} {latest} Played? {played}";
        }
    }

    public ScorePair game5Score;
    public ScorePair game6Score;
    public ScorePair game9Score;
    public ScorePair game10Score;

    public bool LeftDominant
    {
        get
        {
            float leftBrainMax = Math.Max(game5Score.Result, game9Score.Result);
            float rightBrainMax = Math.Max(game6Score.Result, game10Score.Result);
            if(leftBrainMax >= rightBrainMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool RightDominant
    {
        get
        {
            float leftBrainMax = Math.Max(game5Score.Result, game9Score.Result);
            float rightBrainMax = Math.Max(game6Score.Result, game10Score.Result);
            if(rightBrainMax >= leftBrainMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    public DateTime startPlayingTime;

    public enum Sex
    {
        Boy,
        Girl
    }

    public GameSave(string newName, int age, Sex sex)
    {
        this.name = newName;
        this.age = age;
        this.sex = sex;
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
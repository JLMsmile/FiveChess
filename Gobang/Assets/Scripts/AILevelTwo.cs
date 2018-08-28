using UnityEngine;
using System.Collections;
using System.Text;

public class AILevelTwo : AILevelOne
{



    public override void Start()
    {
        toScore.Add("aa___", 100);                      //眠二
        toScore.Add("a_a__", 100);
        toScore.Add("___aa", 100);
        toScore.Add("__a_a", 100);
        toScore.Add("a__a_", 100);
        toScore.Add("_a__a", 100);
        toScore.Add("a___a", 100);


        toScore.Add("__aa__", 500);                     //活二 
        toScore.Add("_a_a_", 500);
        toScore.Add("_a__a_", 500);

        toScore.Add("_aa__", 500);
        toScore.Add("__aa_", 500);


        toScore.Add("a_a_a", 1000);
        toScore.Add("aa__a", 1000);
        toScore.Add("_aa_a", 1000);
        toScore.Add("a_aa_", 1000);
        toScore.Add("_a_aa", 1000);
        toScore.Add("aa_a_", 1000);
        toScore.Add("aaa__", 1000);                     //眠三

        toScore.Add("_aa_a_", 9000);                    //跳活三
        toScore.Add("_a_aa_", 9000);

        toScore.Add("_aaa_", 10000);                    //活三       


        toScore.Add("a_aaa", 15000);                    //冲四
        toScore.Add("aaa_a", 15000);                    //冲四
        toScore.Add("_aaaa", 15000);                    //冲四
        toScore.Add("aaaa_", 15000);                    //冲四
        toScore.Add("aa_aa", 15000);                    //冲四        


        toScore.Add("_aaaa_", 1000000);                 //活四

        toScore.Add("aaaaa", float.MaxValue);           //连五
    }

    public override void CheckOneLine(int[] pos, int[] offset, int chess)
    {
        bool lfirst = true;
        bool lstop = false, rstop = true;
        int allNum = 1;
        string str = "a";

        int ri = offset[0], rj = offset[1];
        int li = -offset[0], lj = -offset[1];

        while (allNum < 7 && (!lstop || !rstop))
        {
            if (lfirst)
            {
                //Left
                if ((pos[0] + li >= 0 && pos[0] + li < 15) && pos[1] + lj >= 0 && pos[1] + lj < 15 && !lstop)
                {
                    if (Chessboard.Instance.grid[pos[0] + li, pos[1] + lj] == chess)
                    {
                        allNum += 1;
                        str += "a" + str;

                    }
                    else if (Chessboard.Instance.grid[pos[0] + li, pos[1] + lj] == 0)
                    {
                        allNum++;
                        str += "_" + str;
                        if (!lstop) lfirst = false;
                    }
                    else
                    {
                        lstop = true;
                        if (!lstop) lfirst = false;
                    }
                    li -= offset[0];
                    lj -= offset[1];
                }
                else
                {
                    lstop = true;
                    if (!rstop) lfirst = false;
                }
            }
            else
            {
                //Right
                if ((pos[0] + ri >= 0 && pos[0] + ri < 15) && pos[1] + rj >= 0 && pos[1] + rj < 15 && !lstop)
                {
                    if (Chessboard.Instance.grid[pos[0] + ri, pos[1] + rj] == chess)
                    {
                        allNum += 1;
                        str += "a";

                    }
                    else if (Chessboard.Instance.grid[pos[0] + ri, pos[1] + rj] == 0)
                    {
                        allNum++;
                        str += "_";
                        if (!lstop) lfirst = true;
                    }
                    else
                    {
                        rstop = true;
                        if (!lstop) lfirst = true;
                    }
                    ri += offset[0];
                    rj += offset[1];
                }
                else
                {
                    rstop = true;
                    if (!lstop) lfirst = true;
                }
            }
        }

        string comStr = "";
        foreach (var keyInfo in toScore)
        {
            if (str.Contains(keyInfo.Key))
            {
                if (comStr != "")
                {
                    if (keyInfo.Value > toScore[comStr])
                    {
                        comStr = keyInfo.Key;
                    }
                }
                else
                {
                    comStr = keyInfo.Key;
                }
            }
        }

        if (comStr != "")
        {
            scor[pos[0], pos[1]] += toScore[comStr];
        }

    }
}

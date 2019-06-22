using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parkingFee
{
    class Program
    {
        static void Main(string[] args)
        {
            //算出有幾個30的區間?
            //判斷，哪一個30的區間，是不用錢
            //判斷，哪幾個30間，20元
            //處理，20元後所有的30元區間，用迴圈(for)包起來處理
            //在 for 迴圈裡面計算金額
            //詢問使用者是否繼續查詢
            
            string input = "";
            do
            {
                Console.WriteLine("****停車費計算****");
                Console.WriteLine("前30分鐘不用錢，31~120分鐘每30分鐘20元，121分鐘起，每30分鐘30元。");
                string startTime = "";
                string endTime = "";
                int result = 0;
                Console.Write("請輸入進場時間：");
                startTime = Console.ReadLine();
                Console.Write("請輸入離場時間：");
                endTime = Console.ReadLine();

                //總分鐘數
                double totalTime = (Convert.ToInt16(endTime.Substring(0, 2)) - Convert.ToInt16(startTime.Substring(0, 2))) * 60 +
                    (Convert.ToInt16(endTime.Substring(2, 2)) - Convert.ToInt16(startTime.Substring(2, 2)));
                double halfHour = Math.Ceiling(totalTime / 30);

                //0<=halfHour<=30 免錢
                //30<halfHour<=120 20區間
                //120<halfHour     30區間
                //三元運算子
                string plan = totalTime <= 30 ? "A" : "B";

                switch (plan)
                {
                    case "A":
                        if (0 < totalTime)
                        {
                            Console.WriteLine("免錢");
                        }
                        else
                        {
                            Console.WriteLine("錯誤的查詢，請重新查詢。");
                        }
                        break;
                    case "B":
                        if (30 < totalTime && totalTime <= 120)
                        {
                            Console.WriteLine($"總計{(halfHour - 1) * 20}元。");
                        }
                        else if (120 < totalTime)
                        {
                            for (int i = 1; i <= halfHour; i++)
                            {
                                result = result + 30;
                            }
                            //第一個halfHour免費，第二、三、四個halfHour是各加20元。而算法為每halfHour加30元，故扣掉多加上的60元。
                            Console.WriteLine($"總計{result - 60}元。");
                        }
                        break;
                    default:
                        break;
                }
                Console.Write("是否繼續查詢Y/N:");
                input = Console.ReadLine();
            } while (input.ToLower() != "n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace UnitTestJenkinsProject1
{
    class StringHelper
    {
        /// <summary>
        /// 預備處理的字串(調整過的錯誤地址)
        /// </summary>
        public string _errAddr { get; set; }

        /// <summary>
        /// 正確的原始字串
        /// </summary>
        public string _oriAddr { get; set; }

        //建構子
        //public StringHelper(string _oriAddr)
        //{
        //    Console.WriteLine("StringHelper 建構子的內容，在初始化階段執行");
        //}

        #region 取得關鍵字字元的位置
        public int _findCityPositionI => _getOneStringPosition(_oriAddr, "縣");
        public int _findCityPositionII => _getOneStringPosition(_oriAddr, "市");
        public int _findVillagePositionI => _getOneStringPosition(_oriAddr, "村");
        public int _findVillagePositionII => _getOneStringPosition(_oriAddr, "鄉");
        public int _findAreaPosition => _getOneStringPosition(_oriAddr, "鎮");
        public int _findLePosition => _getOneStringPosition(_oriAddr, "里");
        public int _findNumPosition => _getOneStringPosition(_oriAddr, "號");
        public int _findStreetPosition => _getOneStringPosition(_oriAddr, "路");
        public int _findFloorPosition => _getOneStringPosition(_oriAddr, "樓");
        public int _findDistindtPosition => _getOneStringPosition(_oriAddr, "區");
        #endregion

        /// <summary>
        /// 搜尋指定字串位置(單一字串)
        /// </summary>
        /// <returns></returns>
        public static int _getOneStringPosition(string _oriStr, string _targetStr)
        {
            var isSucc = _oriStr.IndexOf(_targetStr);
            int targetPosition = 0;
            if (isSucc != -1)
                targetPosition = isSucc;
            else
                targetPosition = -1;

            return targetPosition;
        }

        /// <summary>
        /// 基本處理地址字串oriAddr(比對正確性的時候會以本次處理後為主進行比對)
        /// </summary>
        public string _basicAddrStringProcess(string _str)
        {
            string return_String = "";

            //1. ［台］全部都改為［臺］
            return_String = _str.Replace("台", "臺");
            //2. 其他規則

            return return_String;
        }

        /// <summary>
        /// 根據字串位置去替換該字串位置對應字元
        /// </summary>
        /// <param name="_inputString"></param>
        /// <param name="_inputPosition"></param>
        /// <returns>newString</returns>
        public string _changeStringByPosition(string _inputString, int _inputPosition, string _changeString)
        {
            string newString = _inputString;
            for (int i = 1; i <= _inputString.Length; i++)
            {
                if (_inputPosition == i)
                {
                    newString = _inputString.Substring(0, _inputPosition) + _changeString + _inputString.Substring(_inputPosition + 1);
                    break;
                }
            }
            return newString;
        }

        /// <summary>
        /// 從七種情境中替換地址字串(尚未用到)
        /// </summary>
        /// <param name="_oriString"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public string _changeStringToErrAddrBySwitchCase(string _oriString, int chooseCase)
        {
            string changedString = "";
            switch (chooseCase)
            {
                case 1:
                    changedString = "";
                    break;
                case 2:
                    changedString = "";
                    break;
                case 3:
                    changedString = "";
                    break;
                case 4:
                    changedString = "";
                    break;
                case 5:
                    changedString = "";
                    break;
                case 6:
                    changedString = "";
                    break;
                case 7:
                    changedString = "";
                    break;
                case 8:
                    changedString = "";
                    break;

            }


            return changedString;
        }

        /// <summary>
        /// 檢查檔案如果已經存在就先刪除
        /// </summary>
        /// <param name="_file">"D:\\web\\syscom_addr_report.csv"</param>
        /// <returns>true/false</returns>
        public bool _doCheckHistoryRecord(string _file)
        {
            bool status = false;
            if (File.Exists(_file))
            {
                File.Delete(_file);
                status = true;
            }
            return status;
        }

        /// <summary>
        /// 將正確地址轉換為要測試用的錯誤地址
        /// </summary>
        /// <param name="__oriAddr">欲處理的地址字串</param>
        /// <param name="_type">縣市/行政區/鄉鎮村里</param>
        /// <returns>轉換後的完整地址字串</returns>
        public string _doChangeToErrAddr(string __oriAddr, int _type, string _errType = null)
        {
            string return_string = "";
            string txtType = "";
            int strPosition = 0;

            if (_type == 1)
            {
                txtType = "CITY";

                Console.WriteLine("[縣市]字串區間去裡面取一個字 : findCityPositionI=" + _findCityPositionI + ",findCityPositionII=" + _findCityPositionII);
                if (_findCityPositionI - _findCityPositionII > 0) strPosition = _findCityPositionI - 1;
                else strPosition = _findCityPositionII - 1;
                Console.WriteLine("[縣市]字串區間去裡面取一個字 :預備替換字元位置=[" + strPosition + "]");
                return_string = _changeToErrAddrTypeI(__oriAddr, strPosition);
                Console.WriteLine("[縣市]字串區間去裡面取一個字 :轉換後要測試用的錯誤地址=[" + return_string + "]");

                _writeTxt("D:\\web\\", __oriAddr + "|" + return_string, txtType);
                Console.WriteLine("[縣市]字串區間去裡面取一個字 :writeTxt()-輸出錯誤資料表");
            }
            else if (_type == 2)
            {
                txtType = "DISTRICT";

                Console.WriteLine("[行政區]字串區間去裡面取一個字 : findCityPositionI=" + _findCityPositionI + ",findCityPositionII=" + _findCityPositionII);
                if (_findDistindtPosition > 0)
                {
                    strPosition = _findDistindtPosition - 1;
                    return_string = _changeToErrAddrTypeI(__oriAddr, strPosition);
                }
                else
                {
                    strPosition = -1;
                    return_string = __oriAddr;
                }
                Console.WriteLine("[行政區]字串區間去裡面取一個字 :預備替換字元位置=[" + strPosition + "]");
                Console.WriteLine("[行政區]字串區間去裡面取一個字 :轉換後要測試用的錯誤地址=[" + return_string + "]");

                //輸出錯誤資料表
                _writeTxt("D:\\web\\", __oriAddr + "|" + return_string, txtType);
                Console.WriteLine("writeTxt()");
                Console.WriteLine("[行政區]字串區間去裡面取一個字 :writeTxt()-輸出錯誤資料表");

            }
            else if (_type == 3)//鄉鎮村里
            {
                txtType = "VILLIAGE";

                Console.WriteLine("[村里]字串區間去裡面取一個字 : findCityPositionI=" + _findCityPositionI + ",findCityPositionII=" + _findCityPositionII);

                if (_findVillagePositionI - _findVillagePositionII > 0)
                    strPosition = _findVillagePositionI - 1;
                else if (_findVillagePositionII - _findAreaPosition > 0)
                    strPosition = _findVillagePositionII - 1;
                else if (_findAreaPosition - _findLePosition > 0)
                    strPosition = _findAreaPosition - 1;
                else if (_findLePosition > 0)
                    strPosition = _findLePosition - 1;
                else
                    strPosition = -1;

                if (strPosition != -1) return_string = _changeToErrAddrTypeI(__oriAddr, strPosition);
                else return_string = __oriAddr;

                Console.WriteLine("[村里]字串區間去裡面取一個字 :預備替換字元位置=[" + strPosition + "]");
                Console.WriteLine("[村里]字串區間去裡面取一個字 :轉換後要測試用的錯誤地址=[" + return_string + "]");

                //輸出錯誤資料表
                _writeTxt("D:\\web\\", __oriAddr + "|" + return_string, txtType);
                Console.WriteLine("[村里]字串區間去裡面取一個字 :writeTxt()-輸出錯誤資料表");
            }
            Console.WriteLine("轉換後的錯誤地址:[" + return_string + "]");

            return return_string;
        }

        /// <summary>
        /// 改成錯誤地址 - [縣市]字串區間去裡面取一個字變成○
        /// </summary>
        /// <param name="__oriAddr">預備處理地址</param>
        /// <returns>調整後的錯誤地址字串(類型一)</returns>
        public string _changeToErrAddrTypeI(string __oriAddr, int __strPosition)
        {
            string return_string = "";

            //先去取得要替換的字元位置
            return_string = _changeStringByPosition(__oriAddr, __strPosition, "-");

            //共同替換字元
            return_string = return_string.Replace("仁", "二");
            return_string = return_string.Replace("未", "末");

            return return_string;
        }

        /// <summary>
        /// 寫入TXT-錯誤資料表(100筆).txt 
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="inputString"></param>
        public void _writeTxt(string file_path, string inputString, string type)
        {
            if (!Directory.Exists(file_path)) Directory.CreateDirectory(file_path); //yawen 20190111
            string log_name = "syscom_address_error_" + type + ".txt";
            string _inputString = ConvertUTF8toBIG5(inputString);
            if (!File.Exists(log_name))
            {
                FileStream fs = File.Create(log_name);
                fs.Close();
            }
            File.AppendAllText(log_name, inputString + "\r\n");
        }

        /// <summary>
        /// 把UTF8的string轉為BIG5
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string ConvertUTF8toBIG5(string strInput)
        {
            byte[] strut8 = System.Text.Encoding.Unicode.GetBytes(strInput);
            byte[] strbig5 = System.Text.Encoding.Convert(System.Text.Encoding.Unicode, System.Text.Encoding.Default, strut8);
            return System.Text.Encoding.Default.GetString(strbig5);
        }

        /// <summary>
        /// 寫入Report-分類紀錄資料表(100筆).csv 
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="inputString"></param>
        public static void writeReport(string file_path, string inputString, string type)
        {
            if (!Directory.Exists(file_path)) Directory.CreateDirectory(file_path);
            string log_name = "syscom_address_writeReport_" + type + ".csv";

            if (!File.Exists(log_name))
            {
                FileStream fs = File.Create(log_name);
                fs.Close();
            }
            File.AppendAllText(log_name, inputString + "\r\n");
        }

        /// <summary>
        /// log write-TestCaseProcessYYYYMMDD.log
        /// </summary>
        /// <param name="log_msg"></param>
        public static void write_log_file(string log_msg)
        {
            string _LOG = "D:\\web\\TestProj\\log\\";
            if (!Directory.Exists(_LOG)) Directory.CreateDirectory(_LOG); //yawen 20170724
            string log_name = _LOG + "TestCaseProcess" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            string dttm = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            if (!File.Exists(log_name))
            {
                FileStream fs = File.Create(log_name);
                fs.Close();
            }
            File.AppendAllText(log_name, dttm + " " + log_msg + "\r\n");
        }

        /// <summary>
        /// 如果之前的紀錄報告存在就刪掉
        /// </summary>
        public static void doCheckHistoryRecord()
        {
            if (File.Exists("D:\\web\\syscom_addr_report.csv"))
            {
                File.Delete("D:\\web\\syscom_addr_report.csv");
            }
            if (File.Exists("D:\\web\\syscom_address_error_CITY.txt"))
            {
                File.Delete("D:\\web\\syscom_address_error_CITY.txt");
            }
            if (File.Exists("D:\\web\\syscom_address_error_DISTRICT.txt"))
            {
                File.Delete("D:\\web\\syscom_address_error_DISTRICT.txt");
            }
            if (File.Exists("D:\\web\\syscom_address_error_VILLIAGE.txt"))
            {
                File.Delete("D:\\web\\syscom_address_error_VILLIAGE.txt");
            }
            if (File.Exists("D:\\web\\syscom_address_writeReport_CITY.csv"))
            {
                File.Delete("D:\\web\\syscom_address_writeReport_CITY.csv");
            }
        }
    }
}

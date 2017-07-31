using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace FytSoa.Common
{
   /// <summary>
    /// 分词类
    /// </summary>
    public static class WordSpliter
    {
        #region 属性
        private static string SplitChar = " ";//分隔符
        //用于移除停止词
        public static string[] StopWordsList = new string[] {"的",
            "我们","要","自己","之","将","“","”","，","（","）","后","应","到","某","后",
            "个","是","位","新","一","两","在","中","或","有","更","好"
		};

        private static readonly Hashtable Stopwords = null;
        #endregion
        //
        #region 数据缓存函数
        /// <summary>
        /// 数据缓存函数
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="val">缓存的数据</param>
        private static void SetCache(string key, object val)
        {
            if (val == null)
                val = " ";
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application.Set(key,val);
            System.Web.HttpContext.Current.Application.UnLock();
            //System.Web.HttpContext.Current.Cache.Insert(key, val, null, DateTime.Now.AddSeconds(i), TimeSpan.Zero);
        }

        //private static void SetCache(string key, object val)
        //{
        //    SetCache(key, val, 120);
        //}
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static object GetCache(string key)
        {
            return System.Web.HttpContext.Current.Application.Get(key);
            //return System.Web.HttpContext.Current.Cache[key];
        }
        #endregion
        //
        #region 读取文本
        private static SortedList ReadTxtFile(string filePath)
        {
            if (GetCache("dict") == null)
            {
                Encoding encoding = Encoding.GetEncoding("utf-8");
                SortedList arrText = new SortedList();
                //
                try
                {
                    filePath = System.Web.HttpContext.Current.Server.MapPath(filePath);
                    if (!File.Exists(filePath))
                    {
                        arrText.Add("0","文件" + filePath + "不存在...");
                    }
                    else
                    {
                        if (filePath != null)
                        {
                            StreamReader objReader = new StreamReader(filePath, encoding);
                            string sLine = "";
                            //ArrayList arrText = new ArrayList();

                            while (sLine != null)
                            {
                                sLine = objReader.ReadLine();
                                if (sLine != null)
                                    arrText.Add(sLine, sLine);
                            }
                            //
                            objReader.Close();
                            objReader.Dispose();
                        }
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
                SetCache("dict", arrText);
                //return (string[])arrText.ToArray(typeof(string));
            }
            return (SortedList)GetCache("dict");
        }
        #endregion
        //
        #region 写文本
        //public static void WriteTxtFile(string FilePath, string message)
        //{
        //    try
        //    {
        //        //写文本
        //        StreamWriter writer = null;
        //        //
        //        string filePath = System.Web.HttpContext.Current.Server.MapPath(FilePath);
        //        if (File.Exists(filePath))
        //        {
        //            writer = File.AppendText(filePath);
        //        }
        //        else
        //        {
        //            writer = File.CreateText(filePath);
        //        }
        //        writer.WriteLine(message);
        //        writer.Close();
        //        writer.Dispose();
        //    }
        //    catch (Exception) { }
        //}
        #endregion
        //
        #region 载入词典
        private static SortedList LoadDict => ReadTxtFile(ConfigHelper.GetConfigString("KeyWord"));

        #endregion
        //
        #region 判断某字符串是否在指定字符数组中
        private static bool StrIsInArray(string[] strArray, string val)
        {
            for (int i = 0; i < strArray.Length; i++)
                if (strArray[i] == val) return true;
            return false;
        }
        #endregion
        //
        #region 正则检测
        private static bool IsMatch(string str, string reg)
        {
            return new Regex(reg).IsMatch(str);
        }
        #endregion
        //
        #region 首先格式化字符串(粗分)
        private static string FormatStr(string val)
        {
            string result = "";
            if (string.IsNullOrEmpty(val))
                return "";
            //
            char[] charList = val.ToCharArray();
            //
            string spc = SplitChar;//分隔符
            int strLen = charList.Length;
            int charType = 0; //0-空白 1-英文 2-中文 3-符号
            //
            for (int i = 0; i < strLen; i++)
            {
                string strList = charList[i].ToString();
                if (strList == "")
                    continue;
                //
                if (charList[i] < 0x81)
                {
                    #region
                    if (charList[i] < 33)
                    {
                        if (charType != 0 && strList != "\n" && strList != "\r")
                        {
                            result += " ";
                            charType = 0;
                        }
                        continue;
                    }
                    else if (IsMatch(strList, "[^0-9a-zA-Z@\\.%#:/\\&_-]"))//排除这些字符
                    {
                        if (charType == 0)
                            result += strList;
                        else
                            result += spc + strList;
                        charType = 3;
                    }
                    else
                    {
                        if (charType == 2 || charType == 3)
                        {
                            result += spc + strList;
                            charType = 1;
                        }
                        else
                        {
                            if (IsMatch(strList, "[@%#:]"))
                            {
                                result += strList;
                                charType = 3;
                            }
                            else
                            {
                                result += strList;
                                charType = 1;
                            }//end if No.4
                        }//end if No.3
                    }//end if No.2
                    #endregion
                }//if No.1
                else
                {
                    //如果上一个字符为非中文和非空格，则加一个空格
                    if (charType != 0 && charType != 2)
                        result += spc;
                    //如果是中文标点符号
                    if (!IsMatch(strList, "^[\u4e00-\u9fa5]+$"))
                    {
                        if(charType!=0)
                            result += spc + strList;
                        else
                            result += strList;
                        charType = 3;
                    }
                    else //中文
                    {
                        result += strList;
                        charType = 2;
                    }
                }
                //end if No.1

            }//exit for
            //
            return result;
        }
        #endregion
        //
        #region 分词
        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        private static ArrayList StringSpliter(string[] key)
        {
            ArrayList list = new ArrayList();
            try
            {
                SortedList dict = LoadDict;//载入词典
                //
                for (int i = 0; i < key.Length; i++)
                {
                    if (IsMatch(key[i], @"^(?!^\.$)([a-zA-Z0-9\.\u4e00-\u9fa5]+)$")) //中文、英文、数字
                    {
                        if (IsMatch(key[i], "^[\u4e00-\u9fa5]+$"))//如果是纯中文
                        {
                            //if (!dict.Contains(key[i].GetHashCode()))
                            //    List.Add(key[i]);
                            //
                            int keyLen = key[i].Length;
                            if (keyLen < 2)
                                continue;
                            else if (keyLen <=7)
                                list.Add(key[i]);
                            //
                            //开始分词
                            for (int x = 0; x < keyLen; x++)
                            {
                                //x：起始位置//y：结束位置
                                for (int y = x; y < keyLen; y++)
                                {
                                    string val = key[i].Substring(x, keyLen - y);
                                    if (val.Length < 2)
                                        break;
                                    else if (val.Length > 10)
                                        continue;
                                    if (dict.Contains(val))
                                        list.Add(val);
                                }
                                //
                            }
                            //
                        }
                        //else if (IsMatch(key[i], @"^([0-9]+(\.[0-9]+)*)|([a-zA-Z]+)$"))//纯数字、纯英文
                        //{
                        //    List.Add(key[i]);
                        //}
                        else if (!IsMatch(key[i], @"^(\.*)$"))//不全是小数点
                        {
                            list.Add(key[i]);
                        }
                        //else //中文、英文、数字的混合
                        //{
                        //    List.Add(key[i]);
                        //}
                        //
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
            //
            return list;
            //return (string[])List.ToArray(typeof(string));
        }
        #endregion
        //
        #region 得到分词结果
        /// <summary>
        /// 得到分词结果
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ArrayList DoSplit(string key)
        {
            ArrayList keyList = StringSpliter(FormatStr(key).Split(SplitChar.ToCharArray()));
            //KeyList.Insert(0,key);
            //
            //去掉重复的关键词
            //for (int i = 0; i < KeyList.Count; i++)
            //{
            //    for (int j = 0; j < KeyList.Count; j++)
            //    {
            //        if (KeyList[i].ToString() == KeyList[j].ToString())
            //        {
            //            if (i != j)
            //            {
            //                KeyList.RemoveAt(j);j--;
            //            }
            //        }
            //        //
            //    }
            //}

            //去掉没用的词
            for (int i = 0; i < keyList.Count; i++) {
                if (IsStopword(keyList[i].ToString()))
                {
                    keyList.RemoveAt(i);
                }
            }
            return keyList;
        }

        /// <summary> 
        /// 把一个集合按重复次数排序 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="inputList"></param> 
        /// <returns></returns> 
        public static Dictionary<string, int> SortByDuplicateCount(ArrayList inputList)
        {
            //用于计算每个元素出现的次数，key是元素，value是出现次数 
            Dictionary<string, int> distinctDict = new Dictionary<string, int>();
            for (int i = 0; i < inputList.Count; i++)
            {
                
                //这里没用trygetvalue，会计算两次hash 
               if (distinctDict.ContainsKey(inputList[i].ToString()))
                   distinctDict[inputList[i].ToString()]++;
                else
                   distinctDict.Add(inputList[i].ToString(), 1);
            }
        
            Dictionary<string, int> sortByValueDict = GetSortByValueDict(distinctDict);
            return sortByValueDict;
        }
 

        /// <summary> 
        /// 把一个字典俺value的顺序排序 
        /// </summary> 
        /// <typeparam name="K"></typeparam> 
        /// <typeparam name="V"></typeparam> 
        /// <param name="distinctDict"></param> 
        /// <returns></returns> 
        public static Dictionary<K, V> GetSortByValueDict<K,V>(IDictionary<K, V> distinctDict)
         {
            //用于给tempDict.Values排序的临时数组 
             V[] tempSortList = new V[distinctDict.Count];
              distinctDict.Values.CopyTo(tempSortList, 0);
              Array.Sort(tempSortList); //给数据排序 
             Array.Reverse(tempSortList);//反转 
        
              //用于保存按value排序的字典 
             Dictionary<K, V> sortByValueDict =
                  new Dictionary<K, V>(distinctDict.Count);
              for (int i = 0; i < tempSortList.Length; i++)
              {
                  foreach (KeyValuePair<K, V> pair in distinctDict)
                  {
                        //比较两个泛型是否相当要用Equals，不能用==操作符 
                       if (pair.Value.Equals(tempSortList[i]) && !sortByValueDict.ContainsKey(pair.Key))
                          sortByValueDict.Add(pair.Key, pair.Value);
                  }
              }
              return sortByValueDict;
        }



        /// <summary>
        /// 得到分词关键字，以逗号隔开
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetKeyword(string key)
        {
            string _value = "";
            ArrayList _key = DoSplit(key);
            Dictionary<string, int> distinctDict = SortByDuplicateCount(_key);
            foreach (KeyValuePair<string, int> pair in distinctDict)
            {
                _value+=pair.Key+",";

            }
            return _value;
        }

       /// <summary>
       /// 得到分词关键字，以逗号隔开
       /// </summary>
       /// <param name="key"></param>
       /// <param name="num"></param>
       /// <returns></returns>
       public static string GetKeyword(string key,int num)
        {
            string _value = "";
            ArrayList _key = DoSplit(key);
            Dictionary<string, int> distinctDict = SortByDuplicateCount(_key);
           var index = 0;
            foreach (KeyValuePair<string, int> pair in distinctDict)
            {
                index++;
                _value += pair.Key + ",";
                if(index>=num)
                    break;
            }
            return _value;
        }
        #endregion

        #region 移除停止词
        public static object AddElement(IDictionary collection, Object key, object newValue)
        {
            object element = collection[key];
            collection[key] = newValue;
            return element;
        }

        public static bool IsStopword(string str)
        {
            //int index=Array.BinarySearch(stopWordsList, str)
            return Stopwords.ContainsKey(str.ToLower());
        }
        #endregion

        static WordSpliter()
		{
			if (Stopwords == null)
			{
				Stopwords = new Hashtable();
				double dummy = 0;
				foreach (string word in StopWordsList)
				{
					AddElement(Stopwords, word, dummy);
				}
			}
		}

    }
}

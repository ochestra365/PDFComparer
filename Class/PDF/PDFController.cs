using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFComparer.Class.PDF;
namespace PDFComparer.Class.PDF
{
    class PDFController
    {
        public static int GetPages(byte[] _arr)
        {
            try
            {
                string result = string.Empty;
                char[] charArr = new char[16];
                for(int i = 0; i < 16; i++)
                {
                    charArr[i] = Convert.ToChar(_arr[i+144]);
                }
                result = new string(charArr).Replace(" ",string.Empty);
                string[] arrString= result.Split('/');
                result = string.Empty;
                result =arrString.FirstOrDefault<string>(x => x.Contains("Count"));
                if (!string.IsNullOrEmpty(result))
                {
                    if(int.TryParse(result.Replace("Count", ""),out int pages))
                    {
                        return pages;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return 0;
        }

        public static bool IsPDFSignautre(byte [] _arr)
        {
            try
            {
                for(int i = 0; i < 5; i++)
                {
                    if (!_arr[i].Equals(PDFElement.Signature[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public static string GetLanguge(byte[] _arr)
        {
            try
            {
                char[] tempChararr = new char[35];
                for(int i = 0; i < 35; i++)
                {
                    tempChararr[i] = Convert.ToChar(_arr[i + 32]);
                }
                string[] temp = new string(tempChararr).Replace(" ", string.Empty).Split('/');
                string tempString=new string(tempChararr).Replace(" ", string.Empty).Split('/').FirstOrDefault<string>(x => x.Contains("Lang"));
                if (!string.IsNullOrEmpty(tempString))
                {
                    return tempString.Replace("Lang", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TIME : {DateTime.Now}. ERROR : {ex}");
            }
            return string.Empty;
        }

        public static List< byte[] > GetPDFKids(byte[] _arr, int _pages)
        {
            List<byte[]> result = new List<byte[]>();
            try
            {
                int kidsIndex = 0;
                for(int i = 0; i < 224; i++)
                {
                    if(_arr[i].Equals((byte)0x4b)&& _arr[i+1].Equals((byte)0x69)&& _arr[i+2].Equals((byte)0x64)&& _arr[i+3].Equals((byte)0x73))
                    {
                        kidsIndex = i+5;
                        break;
                    }
                }

                for(int i = kidsIndex; i < _pages; i++)
                {
                    byte[] temp = new byte[6];
                    for(int j = i; j < 6; j++)
                    {
                        temp= _arr
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"TIME : {DateTime.Now}. {ex}");
            }
            return result;
        }
    }
}

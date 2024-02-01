using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using iTextSharp.text.pdf;

namespace PDFComparer.Class.PDF
{
    class PDFController
    {
        /*
         * 0. 한글 추출 itextSharp 한글 추출 방법 찾기
         * [PDF 문자 비교]
         * 1. PDF 존재 확인
         * 2. 각 PDF 파일 비교 페이지 확인
         * 3. 각 PDF 텍스트 추출(1차 목표)
         * 4. pdf파일의 다른 점을 확인
         * 5. 다른 문자를 붉은 색으로 표기
        */
        /// <summary>
        /// ISOS PSC : Method of determining if PDF files are the same
        /// </summary>
        /// <param name="fileNames">PDF files Selected</param>
        /// <param name="pdf1Page">original PDF File page number.</param>
        /// <param name="pdf2Page">target PDF File page number.</param>
        /// <returns>JUDGE</returns>
        public bool Compare(ref List<string> fileNames, int pdf1Page, int pdf2Page)
        {
            FileInfo PDF1_Info = new FileInfo(fileNames[0]);
            FileInfo PDF2_Info = new FileInfo(fileNames[1]);
            if (!PDF1_Info.Exists) { Console.WriteLine($"TIME : {DateTime.Now}.\nERROR : {PDF1_Info.Name} 파일이 존재하지 않습니다."); return false; }
            if (!PDF2_Info.Exists) { Console.WriteLine($"TIME : {DateTime.Now}.\nERROR : {PDF2_Info.Name} 파일이 존재하지 않습니다."); return false; }

            PdfReader PDF1 = new PdfReader(PDF1_Info.FullName);
            PdfReader PDF2 = new PdfReader(PDF2_Info.FullName);
            try
            {
                if (fileNames.Count == 2)
                {
                    if (File.ReadAllBytes(fileNames[0]).SequenceEqual(File.ReadAllBytes(fileNames[1]))) 
                    { 
                        Console.WriteLine($"TIME : {DateTime.Now}\nSAME"); 
                        return true; 
                    }
                    if (!fileNames[0].Equals(fileNames[1]))
                    {
                        if (PDF1.NumberOfPages < pdf1Page) 
                        { 
                            Console.WriteLine($"TIME : {DateTime.Now}.\nERROR : {PDF1_Info.Name} Pages Over"); 
                            return false; 
                        }
                        if (PDF2.NumberOfPages < pdf2Page) 
                        { 
                            Console.WriteLine($"TIME : {DateTime.Now}.\nERROR : {PDF2_Info.Name} Pages OVer"); 
                            return false; 
                        }
                        string pdf1Str = GetStringFromPDF(PDF1, pdf1Page);
                        string pdf2Str = GetStringFromPDF(PDF2, pdf2Page);
                        if (!string.IsNullOrEmpty(pdf1Str) && !string.IsNullOrEmpty(pdf2Str))
                        {
                            // The Verified Value that i want to deliver.
                            return pdf1Str.Equals(pdf2Str);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"TIME : {DateTime.Now}.\nERROR : 비교하고자 하는 파일의 이름이 서로 같습니다.");
                        fileNames.Clear();
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("비교하고자 하는 파일이 2개가 아닙니다.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TIME: {DateTime.Now}.\nERROR : {ex}");
            }
            finally
            {
                PDF1.Close();
                PDF2.Close();
                fileNames.Clear();
            }
            return false;
        }
        /// <summary>
        /// 240201 ISOS PSC : Get String From PDF.
        /// </summary>
        /// <param name="pdf">PDF file Contents</param>
        /// <param name="page">The Page Number I want to Compare.</param>
        /// <returns>The String data of PDF file</returns>
        private string GetStringFromPDF(PdfReader pdf, int page)
        {
            string result = string.Empty;
            try
            {
                PdfContentParser parser = new PdfContentParser(new PRTokeniser(pdf.GetPageContent(page)));
                StringBuilder builder = new StringBuilder();
                while (parser.Tokeniser.NextToken())
                {
                    if (parser.Tokeniser.TokenType == PRTokeniser.TK_STRING)
                    {
                        string str = parser.Tokeniser.StringValue;
                        builder.Append(str);
                    }
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TIME : {DateTime.Now}. ERROR : {ex}");
                return string.Empty;
            }
            return string.Empty;
        }
        #region 보류
        public static int GetPages(byte[] _arr)
        {
            try
            {
                string result = string.Empty;
                char[] charArr = new char[16];
                for (int i = 0; i < 16; i++)
                {
                    charArr[i] = Convert.ToChar(_arr[i + 144]);
                }
                result = new string(charArr).Replace(" ", string.Empty);
                string[] arrString = result.Split('/');
                result = string.Empty;
                result = arrString.FirstOrDefault<string>(x => x.Contains("Count"));
                if (!string.IsNullOrEmpty(result))
                {
                    if (int.TryParse(result.Replace("Count", ""), out int pages))
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

        public static bool IsPDFSignautre(byte[] _arr)
        {
            try
            {
                for (int i = 0; i < 5; i++)
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
                for (int i = 0; i < 35; i++)
                {
                    tempChararr[i] = Convert.ToChar(_arr[i + 32]);
                }
                string[] temp = new string(tempChararr).Replace(" ", string.Empty).Split('/');
                string tempString = new string(tempChararr).Replace(" ", string.Empty).Split('/').FirstOrDefault<string>(x => x.Contains("Lang"));
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
        /// <summary>
        /// 페이지 ID 컬렉션 반환
        /// </summary>
        /// <param name="_arr">PDF 바이트 배열</param>
        /// <param name="_pages">총 페이지 수량</param>
        /// <returns>페이지에 따른 아이디 컬렉션</returns>
        public static Dictionary<int, string> GetPDFKids(byte[] _arr, int _pages)
        {
            Dictionary<int, string> dicResult = new Dictionary<int, string>();
            try
            {
                int kidsIndex = 0;
                for (int i = 0; i < 224; i++)
                {
                    if (_arr[i].Equals((byte)0x4b) && _arr[i + 1].Equals((byte)0x69) && _arr[i + 2].Equals((byte)0x64) && _arr[i + 3].Equals((byte)0x73))
                    {
                        kidsIndex = i + 6;
                        break;
                    }
                }
                char[] tempChar = new char[7 * _pages];
                string[] tempStringArr = new string[_pages];
                for (int j = 0; j < 7 * _pages; j++)
                {
                    tempChar[j] = Convert.ToChar(_arr[kidsIndex + j]);
                }
                tempStringArr = new string(tempChar).Trim().Replace(" ", string.Empty).Split('R');
                if (tempStringArr.Length != _pages)
                {
                    return null;
                }
                else
                {
                    for (int page = 0; page < _pages; page++)
                    {
                        // object Kids를 페이지로 봤다. 확인 필요
                        dicResult.Add(page + 1, tempStringArr[page]);
                    }
                }
                return dicResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TIME : {DateTime.Now}.\n{ex}");
            }
            return null;
        }
        #endregion
    }
}

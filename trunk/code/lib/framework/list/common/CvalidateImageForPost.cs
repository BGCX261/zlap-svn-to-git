using System;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
/// <summary>
/// sunglb@thoidai.net
/// </summary>
namespace framework.list.common
{
    public class CvalidateImageForPost
    {
        //Attribute:
        string[] typeFile = new string[] { "jpg", "bmp", "gif", "png", "swf" };
        public CvalidateImageForPost()
        {
        }
        #region Test File Upload:
        public string GetTypeFile()
        {
            string str = "";
            int NumType = typeFile.Length;
            for (int i = 0; i < NumType; i++)
            {
                str = str + "*." + typeFile[i] + ",";
            }
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }
        public bool TestTypeFile(HtmlInputFile file)
        {
            bool test = false;
            try
            {
                string strName = GetExtension(file.PostedFile.FileName);
                int numTypeFile = typeFile.Length;
                for (int i = 0; i < numTypeFile; i++)
                {
                    if (strName.ToLower().Equals(typeFile[i]))
                    {
                        test = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool TestExistFileUpload(HtmlInputFile file)
        {
            bool test = false;
            try
            {
                if (file.PostedFile.ContentLength != 0)
                {
                    test = true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool TestMinImageWidth(HtmlInputFile file, int min)
        {
            bool test = false;
            try
            {
                if (min > 0)
                {
                    System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(file.PostedFile.InputStream);
                    if (CheckSize.PhysicalDimension.Width <= min)
                    {
                        test = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool TestMinImageHeight(HtmlInputFile file, int min)
        {
            bool test = false;
            try
            {
                if (min > 0)
                {
                    System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(file.PostedFile.InputStream);
                    if (CheckSize.PhysicalDimension.Height < min)
                    {
                        test = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool TestMaxImageWidth(HtmlInputFile file, int Max)
        {
            bool test = false;
            try
            {
                if (Max > 0)
                {
                    System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(file.PostedFile.InputStream);
                    if (CheckSize.PhysicalDimension.Width > Max)
                    {
                        test = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool TestMaxImageHeight(HtmlInputFile file, int Max)
        {
            bool test = false;
            try
            {
                if (Max > 0)
                {
                    System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(file.PostedFile.InputStream);
                    if (CheckSize.PhysicalDimension.Height > Max)
                    {
                        test = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool TestMaxSizeImage(HtmlInputFile file, int max)
        {
            bool test = false;
            try
            {
                if (file.PostedFile != null)
                {
                    if (file.PostedFile.ContentLength > max)
                    {
                        test = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool UploadFile(HtmlInputFile file, String pathSave, String fileSaveName)
        {
            bool test = false;
            try
            {
                file.PostedFile.SaveAs(pathSave + "/" + fileSaveName);
                test = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool UploadFile_server(HtmlInputFile file, String fileSaveName)
        {
            bool test = false;
            try
            {
                file.PostedFile.SaveAs(fileSaveName);
                test = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public string GetExtension(string FileName)
        {
            string[] split = FileName.Split('.');
            string Extension = split[split.Length - 1];
            return Extension.ToLower();
        }
        public bool DeleteFile(string pathDelete, string fileName)
        {
            bool test = false;
            try
            {
                FileInfo fileInfo = new FileInfo(pathDelete + "/" + fileName);
                fileInfo.Delete();
                test = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool TestMaxSizeImage(FileUpload file, int max)
        {
            bool test = false;
            try
            {
                if (file.PostedFile != null)
                {
                    if (file.PostedFile.ContentLength > max)
                    {
                        test = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool TestTypeFile(FileUpload file)
        {
            bool test = false;
            try
            {
                string strName = GetExtension(file.PostedFile.FileName);
                int numTypeFile = typeFile.Length;
                for (int i = 0; i < numTypeFile; i++)
                {
                    if (strName.ToLower().Equals(typeFile[i]))
                    {
                        test = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool UploadFile(FileUpload file, String pathSave, String fileSaveName)
        {
            bool test = false;
            try
            {
                file.PostedFile.SaveAs(pathSave + "/" + fileSaveName);
                test = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool UploadFile(FileUpload file, String _path)
        {
            bool test = false;
            try
            {
                file.PostedFile.SaveAs(_path);
                test = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        public bool DeleteFile(string url)
        {
            bool test = false;
            try
            {
                FileInfo fileInfo = new FileInfo(url);
                fileInfo.Delete();
                test = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return test;
        }
        #endregion
    }
}
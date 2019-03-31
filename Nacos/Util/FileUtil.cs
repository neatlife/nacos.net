using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Com.Alibaba.Nacos.Util
{
    public class FileUtil
    {
        protected static string ds = Path.DirectorySeparatorChar.ToString();
        
        public static string Read(string path)
        {
            return File.ReadAllText(@path);
        }

        public static void Write(string path, string content)
        {
            System.IO.File.WriteAllText(@path, content);
        }
        
        public static List<string> FindFile(string sSourcePath, string filter)
        {
            List<String> list = new List<string>();
            //遍历文件夹
            DirectoryInfo theFolder = new DirectoryInfo(sSourcePath);
            FileInfo[] thefileInfo = theFolder.GetFiles(filter, SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile in thefileInfo)  //遍历文件
                list.Add(NextFile.FullName);
            //遍历子文件夹
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            foreach (DirectoryInfo NextFolder in dirInfo)
            {
                //list.Add(NextFolder.ToString());
                FileInfo[] fileInfo = NextFolder.GetFiles(filter, SearchOption.AllDirectories);
                foreach (FileInfo NextFile in fileInfo)  //遍历文件
                    list.Add(NextFile.FullName);
            }
            return list;
        }

        public static bool DeleteFiles(string path)
        {
            if (Directory.Exists(path) == false)
            {
                return false;
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            try
            {
                foreach (var item in files)
                {
                    File.Delete(item.FullName);
                }
                if (dir.GetDirectories().Length != 0)
                {
                    foreach (var item in dir.GetDirectories())
                    {
                        if (!item.ToString().Contains("$") && (!item.ToString().Contains("Boot")))
                        {
                            DeleteFiles(dir.ToString() + ds + item.ToString());
                        }
                    }
                }
                Directory.Delete(path);

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        
        /// <summary>
        /// 文件拷贝
        /// </summary>
        /// <param name="source">源文件路径</param>
        /// <param name="target">目标路径</param>
        /// <returns></returns>
        public static bool Copy(string source, string target)
        {
            try
            {
                File.Copy(source, target, false);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

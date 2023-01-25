using System.Xml.Linq;

namespace EBusiness.Helpers
{
    public static class FileManager
    {
        public static string SaveFile(string root, string fileName,IFormFile formFile)
        {
            string name = formFile.FileName;
            if(name.Length > 64 ) { 
                name = name.Substring(name.Length-64,64);
            }
            name=Guid.NewGuid().ToString()+name;
            string path=Path.Combine(root,fileName,name);
            using(FileStream fs=new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(fs);
            }
            return name;
        }
        public static void DeleteFile(string root, string fileName, string fileUrl)
        {
            string path = Path.Combine(root, fileName, fileUrl);
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Diagnostics;

namespace FileExplorer.Controllers
{
    
    public class FolderController : ApiController
    {
        public IEnumerable<FolderPath> Get(string path)
        {
            List<FolderPath> folders = new List<FolderPath>();
            string dir = @"C:\Users\jml0007\Documents\Visual Studio 2013\Projects\FileExplorer\FileExplorer\media\" + System.Net.WebUtility.UrlDecode(path);
            DirectoryInfo dirInfo = new DirectoryInfo(dir);

            if (dirInfo.Exists)
            {
                foreach (DirectoryInfo dInfo in dirInfo.GetDirectories())
                {
                    folders.Add(new FolderPath() { path = @"\" + dInfo.Name, name = dInfo.Name });
                }

                return folders.ToList();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public class FolderPath
        {
            public string path { get; set; }
            public string name { get; set; }
        }
    }
    
    public class FileController : ApiController
    {
        public IEnumerable<FilePath> Get(string path)
        {
            List<FilePath> files = new List<FilePath>();
            string root = @"C:\Users\jml0007\Documents\Visual Studio 2013\Projects\FileExplorer\FileExplorer\media\";
            string localpath = System.Net.WebUtility.UrlDecode(path);
            string dir = root + localpath;
            DirectoryInfo dirInfo = new DirectoryInfo(dir);

            if (dirInfo.Exists)
            {
                foreach (FileInfo fInfo in dirInfo.GetFiles())
                {
                    files.Add(new FilePath() { path = "/media/" + localpath + "/" + fInfo.Name, name = fInfo.Name });
                }

                return files.ToList();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        
        public class FilePath
        {
            public string path { get; set; }
            public string name { get; set; }
        }

        // GET: api/File/5
        //public string Get()
        //{
        //    return "value";
        //}

        // POST: api/File
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/File/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/File/5
        public void Delete(int id)
        {
        }
    }
}

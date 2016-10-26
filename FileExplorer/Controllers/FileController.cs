using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;

namespace FileExplorer.Controllers
{
    
    public class FolderController : ApiController
    {
        public IEnumerable<FolderPath> Get()
        {
            List<FolderPath> folders = new List<FolderPath>();
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\leffj\Music\");

            foreach (DirectoryInfo dInfo in dirInfo.GetDirectories())
            {
                folders.Add(new FolderPath() { path = @"\" + dInfo.Name });
            }

            return folders.ToList();
        }

        public class FolderPath
        {
            public string path { get; set; }
        }
    }
    
    public class FileController : ApiController
    {
        public IEnumerable<FilePath> Get(string path)
        {
            List<FilePath> files = new List<FilePath>();
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\leffj\Music\" + path);

            if (dirInfo.Exists)
            {
                foreach (FileInfo fInfo in dirInfo.GetFiles())
                {
                    files.Add(new FilePath() { path = @"\" + fInfo.Name });
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

using DiffPlex.DiffBuilder.Model;
using System.Collections.Generic;

namespace DiffWeb.Models
{
    public class filelist
    {

        public List<file> fileList { get;  }


        public filelist()
        {
            fileList = new List<file>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEData.Application
{
    public interface IFileService
    {
        public string GetImageObject(string imagePath);
    }
}

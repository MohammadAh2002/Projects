using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ConfigurationModels
{
    public class StaticFilePaths
    {
        public string RootPath { get; set; } = string.Empty;
        public string ImagesFolder { get; set; } = "Images";
        public string DocumentsFolder { get; set; } = "Documents";
    }
}

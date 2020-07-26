using DataAccess.Layouts;
using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class FilePreviewModel
    {
        public List<Record> Records { get; set; } = new List<Record>();
        public string KeyFieldName { get; set; }

    }
}

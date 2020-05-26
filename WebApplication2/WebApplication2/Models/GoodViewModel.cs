using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class GoodViewModel
    {
        public Good Good { set; get; }
        public IFormFile UploadedFile { set; get; }
    }
}

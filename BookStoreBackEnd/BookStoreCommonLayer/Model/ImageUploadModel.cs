using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace BookStoreCommonLayer.Model
{
    public class ImageUploadModel
    {
        public IFormFile ImgFile { get; set; }
        public string Book_Id { get; set; }
    }
}

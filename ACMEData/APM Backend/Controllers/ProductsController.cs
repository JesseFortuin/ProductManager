using ACMEData.Application;
using Microsoft.AspNetCore.Mvc;
using ACMEData.Shared;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Data;
using ClosedXML.Excel;

namespace APM_Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductFacade productsFacade;
        private readonly IFileService fileService;
        private readonly IWebHostEnvironment ev;

        public ProductsController(
            IProductFacade productsFacade,
            IFileService fileService,
            IWebHostEnvironment ev)
        {
            this.productsFacade = productsFacade;
            this.fileService = fileService;
            this.ev = ev;
        }

        [HttpGet("products")]
        public ActionResult GetProducts()
        {
            var products = productsFacade.GetProducts();

            foreach (var product in products)
            {
                var image = GetImage(product.productCode);

                product.imageBase64 = image;
            }

            return Ok(products);
        }

        [HttpPut("UploadImage")]
        public ActionResult UploadImage(IFormFile file, string productCode) 
        {
            ApiResponseFormat format = new ApiResponseFormat();
            try
            {
                string filePath = GetFilePath(productCode);

                if (!System.IO.Directory.Exists(filePath)) 
                { 
                    System.IO.Directory.CreateDirectory(filePath);
                }

                string imagePath = filePath + "\\" + productCode + ".png";

                if (System.IO.File.Exists(imagePath)) 
                { 
                    System.IO.File.Delete(imagePath);
                }

                using (FileStream stream = System.IO.File.Create(imagePath)) 
                {
                    file.CopyTo(stream);

                    return NoContent();
                }
            }
            catch (Exception e) 
            {
                return BadRequest(e);
            }
        }

        [HttpPut("UploadImages")]
        public ActionResult UploadImages(IFormFileCollection files, string productCode)
        {
            try
            {
                string filePath = GetFilePath(productCode);

                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }

                foreach ( var file in files) 
                {
                    //string imagePath = filePath + "\\" + productCode + ".png";

                    string imagePath = filePath + "\\" + file.FileName;

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (FileStream stream = System.IO.File.Create(imagePath))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
            catch (Exception e)
            {
               return BadRequest(e);
            }

            return NoContent();
        }

        [HttpGet("excel")]
        public ActionResult ExportExcel()
        {
            var data = GetData();

            using(XLWorkbook wb = new XLWorkbook())
            {
                wb.AddWorksheet(data, "Product Data");

                using(MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    
                    return File(ms.ToArray(), 
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ProductData.xlsx");
                }
            }
        }

        [NonAction]
        private DataTable GetData() 
        {
            var dt = new DataTable();

            dt.TableName = "ProductData";
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("ProductCode", typeof(string));
            dt.Columns.Add("ReleaseDate", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Price", typeof(double));
            dt.Columns.Add("StarRating", typeof(double));

            var products = productsFacade.GetProducts();

            foreach ( var product in products) 
            { 
                dt.Rows.Add(product.productName,
                            product.productCode,
                            product.releaseData,
                            product.description,
                            product.price,
                            product.starRating);
            }
            return dt;
        }

        //[HttpGet("GetImage")]
        //public ActionResult GetImage (string productCode) 
        //{ 
        //    string imageUrl = string.Empty;

        //    string hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

        //    try 
        //    {
        //        string filePath = GetFilePath(productCode);

        //        string imagePath = filePath + "\\" + productCode + ".png";

        //        if (System.IO.File.Exists(imagePath))
        //        {
        //            imageUrl = hostUrl + "Images" + "/" + productCode + ".png";
        //        }

        //        else
        //        {
        //            return NotFound();
        //        }

        //    }

        //    catch (Exception e) 
        //    {

        //    }

        //    return Ok(imageUrl);
        //}

        [NonAction]
        public string GetImage(string productCode)
        {
            string imageUrl = string.Empty;

            string hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            string filePath = GetFilePath(productCode);

            string imagePath = filePath + "\\" + productCode + ".png";

            if (System.IO.File.Exists(imagePath))
            {
                //imageUrl = hostUrl + "Images" + "/" + productCode + ".png";
                imageUrl = fileService.GetImageObject(imagePath);
            }

            else
            {
                return "Image not Found";
            }

            return imageUrl;
        }

        [NonAction]
        public string GetFilePath(string productCode)
        {
            return this.ev.WebRootPath + "\\Images";
        }
    }
}

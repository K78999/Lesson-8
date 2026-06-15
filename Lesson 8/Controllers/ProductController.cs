using Lesson_8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_8.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static List<Product> Products = new List<Product>
        {
            new Product 
            { 
                Id = 1, 
                Name = "Product 1", 
                Price = 100000, 
                ImagePath = "/uploads/default.jpg",
                ImagePaths = new List<string> { "/uploads/default.jpg" }
            },
            new Product 
            { 
                Id = 2, 
                Name = "Product 2", 
                Price = 200000, 
                ImagePath = "/uploads/default.jpg",
                ImagePaths = new List<string> { "/uploads/default.jpg" }
            }
        };

        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Product/Index
        public IActionResult Index()
        {
            return View(Products);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, decimal price, IFormFileCollection files)
        {
            if (string.IsNullOrEmpty(name) || price <= 0)
            {
                ViewBag.Message = "Tên sản phẩm và giá phải hợp lệ!";
                return View();
            }

            // Validate files
            if (files == null || files.Count == 0)
            {
                ViewBag.Message = "Vui lòng chọn ít nhất một hình ảnh!";
                return View();
            }

            List<string> uploadedPaths = new List<string>();
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

            // Create uploads folder if it doesn't exist
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            foreach (var file in files)
            {
                // Validate file type
                if (!IsValidImageFile(file))
                {
                    ViewBag.Message = $"Tệp '{file.FileName}' không hợp lệ! Chỉ hỗ trợ jpg/png.";
                    return View();
                }

                // Generate unique filename
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                uploadedPaths.Add("/uploads/" + uniqueFileName);
            }

            // Add product
            var product = new Product
            {
                Id = Products.Count > 0 ? Products.Max(p => p.Id) + 1 : 1,
                Name = name,
                Price = price,
                ImagePath = uploadedPaths.FirstOrDefault(),
                ImagePaths = uploadedPaths,
                CreatedDate = DateTime.Now
            };

            Products.Add(product);

            ViewBag.Message = "Thêm sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        // Validate if file is jpg or png
        private bool IsValidImageFile(IFormFile file)
        {
            // Check file extension
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return false;
            }

            // Check MIME type
            var allowedMimeTypes = new[] { "image/jpeg", "image/png" };
            if (!allowedMimeTypes.Contains(file.ContentType))
            {
                return false;
            }

            // Check file size (max 5MB)
            if (file.Length > 5 * 1024 * 1024)
            {
                return false;
            }

            return true;
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string name, decimal price, IFormFileCollection files)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(name) || price <= 0)
            {
                ViewBag.Message = "Tên sản phẩm và giá phải hợp lệ!";
                return View(product);
            }

            product.Name = name;
            product.Price = price;

            // Handle new images if uploaded
            if (files != null && files.Count > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                List<string> newPaths = new List<string>();

                foreach (var file in files)
                {
                    if (!IsValidImageFile(file))
                    {
                        ViewBag.Message = $"Tệp '{file.FileName}' không hợp lệ! Chỉ hỗ trợ jpg/png.";
                        return View(product);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    newPaths.Add("/uploads/" + uniqueFileName);
                }

                product.ImagePaths = newPaths;
                product.ImagePath = newPaths.FirstOrDefault();
            }

            ViewBag.Message = "Cập nhật sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
}

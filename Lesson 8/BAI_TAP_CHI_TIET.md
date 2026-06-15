# Bài tập: Quản lý sản phẩm - Tải lên hình ảnh

## 📋 Yêu cầu bài tập

### Mục tiêu
- ✅ Upload file
- ✅ Lưu ảnh lên server

### Yêu cầu chức năng
Trong module **Product** (Sản phẩm):
- Cho phép upload: **Hình sản phẩm (1 hoặc nhiều ảnh)**

### Điều kiện xác thực
| Điều kiện | Kết quả |
|-----------|--------|
| jpg/png | Cho upload ✅ |
| File khác | Báo lỗi ❌ |

### Hiển thị
Danh sách sản phẩm phải hiển thị:
- ✅ **Tên** sản phẩm
- ✅ **Giá** sản phẩm
- ✅ **Hình ảnh** sản phẩm

---

## 🏗️ Cấu trúc dự án

### Tệp tạo mới

1. **Models/Product.cs**
   - Model dữ liệu cho sản phẩm
   - Properties: Id, Name, Price, ImagePath, ImagePaths, CreatedDate

2. **Controllers/ProductController.cs**
   - ProductController quản lý CRUD sản phẩm
   - Hàm Create: Thêm sản phẩm + upload hình
   - Hàm Index: Hiển thị danh sách sản phẩm
   - Hàm Edit: Chỉnh sửa sản phẩm
   - Hàm Delete: Xóa sản phẩm

3. **Views/Product/**
   - Index.cshtml: Danh sách sản phẩm (bảng)
   - Create.cshtml: Form thêm sản phẩm mới
   - Edit.cshtml: Form chỉnh sửa sản phẩm
   - Delete.cshtml: Xác nhận xóa

4. **wwwroot/uploads/** (Folder mới)
   - Lưu trữ hình ảnh của sản phẩm

---

## 🎯 Tính năng chi tiết

### 1️⃣ Tải lên ảnh

**Endpoint:** `POST /Product/Create`

**Xác thực:**
```csharp
✅ Kiểm tra phần mở rộng: .jpg, .jpeg, .png
✅ Kiểm tra MIME type: image/jpeg, image/png
✅ Giới hạn kích thước: 5MB/tệp
✅ Báo lỗi nếu vi phạm
```

**Lưu trữ:**
- Tên tệp được random: `{GUID}.{extension}`
- Đường dẫn: `/uploads/{filename}`
- Thư mục: `wwwroot/uploads/`

### 2️⃣ Danh sách sản phẩm

**Endpoint:** `GET /Product/Index`

**Hiển thị:**
| Cột | Nội dung |
|-----|---------|
| Hình ảnh | Thumbnail 80x80px |
| Tên sản phẩm | Text |
| Giá (VNĐ) | Số định dạng |
| Ngày tạo | Datetime |
| Hành động | Sửa / Xóa |

### 3️⃣ Chỉnh sửa sản phẩm

**Endpoint:** `GET/POST /Product/Edit/{id}`

**Chức năng:**
- Hiển thị hình ảnh hiện tại
- Option cập nhật hình ảnh mới (tùy chọn)
- Sửa tên và giá sản phẩm

### 4️⃣ Xóa sản phẩm

**Endpoint:** `GET/POST /Product/Delete/{id}`

**Chức năng:**
- Xác nhận trước khi xóa
- Hiển thị thông tin sản phẩm
- Xóa sản phẩm khỏi danh sách

---

## 🚀 Cách sử dụng

### Chạy ứng dụng

```bash
# Mở terminal tại thư mục dự án
cd "Lesson 8"

# Chạy ứng dụng
dotnet run

# Hoặc sử dụng Visual Studio: Ctrl+F5
```

**Truy cập:** `https://localhost:xxxx` hoặc `http://localhost:xxxx`

### Quy trình thêm sản phẩm

1. **Nhấp vào "Xem danh sách sản phẩm"** trên trang chủ
2. **Nhấp nút "Thêm sản phẩm mới"**
3. **Nhập thông tin:**
   - Tên sản phẩm (bắt buộc)
   - Giá (> 0, bắt buộc)
4. **Chọn hình ảnh:**
   - Click vào input file
   - Chọn 1 hoặc nhiều file (JPG/PNG)
   - Preview sẽ hiển thị tự động
5. **Nhấp "Lưu sản phẩm"**
   - Nếu hợp lệ → Thêm thành công, quay về danh sách
   - Nếu không hợp lệ → Hiển thị lỗi

### Chỉnh sửa / Xóa sản phẩm

1. **Danh sách sản phẩm** → Chọn sản phẩm
2. **Nút "Sửa":** Cập nhật thông tin
3. **Nút "Xóa":** Xác nhận xóa sản phẩm

---

## 🔍 Test kiểm chứng

### Test Upload

| Test | Tệp | Kết quả mong đợi | ✅ |
|------|-----|------------------|-----|
| Upload JPG | photo.jpg | Thành công | ✅ |
| Upload PNG | image.png | Thành công | ✅ |
| Upload GIF | image.gif | Lỗi: "Không hỗ trợ" | ✅ |
| Upload TXT | file.txt | Lỗi: "Không hỗ trợ" | ✅ |
| Upload >5MB | large.jpg | Lỗi: "Quá lớn" | ✅ |

### Test Xác thực

| Test | Input | Kết quả mong đợi | ✅ |
|------|-------|------------------|-----|
| Tên trống | "", giá: 100 | Lỗi: "Tên bắt buộc" | ✅ |
| Giá âm | "Product", -100 | Lỗi: "Giá phải >0" | ✅ |
| Không chọn ảnh | "Product", 100, [] | Lỗi: "Chọn ảnh" | ✅ |
| Input hợp lệ | "Product", 100, image.jpg | Thành công ✅ | ✅ |

### Test Hiển thị

| Test | Kỳ vọng | ✅ |
|------|---------|-----|
| Hiển thị tên sản phẩm | ✅ | ✅ |
| Hiển thị giá | ✅ | ✅ |
| Hiển thị hình ảnh | ✅ | ✅ |
| Thumbnail size | 80x80px | ✅ |
| Bảng responsive | ✅ | ✅ |

---

## 📁 Cấu trúc sau khi chạy

```
Lesson 8/
├── Lesson 8.csproj
├── Program.cs
├── Models/
│   ├── ErrorViewModel.cs
│   └── Product.cs                    ⭐ NEW
├── Controllers/
│   ├── HomeController.cs
│   └── ProductController.cs          ⭐ NEW
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml (cập nhật)
│   │   └── Privacy.cshtml
│   ├── Product/                      ⭐ NEW FOLDER
│   │   ├── Index.cshtml              ⭐ NEW
│   │   ├── Create.cshtml             ⭐ NEW
│   │   ├── Edit.cshtml               ⭐ NEW
│   │   └── Delete.cshtml             ⭐ NEW
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── _Layout.cshtml.css
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/
│   ├── uploads/                      ⭐ NEW FOLDER (Lưu ảnh)
│   ├── images/
│   │   └── no-image.png
│   ├── css/
│   ├── js/
│   └── lib/
└── appsettings.json
```

---

## ⚙️ Công nghệ sử dụng

| Công nghệ | Phiên bản | Mục đích |
|----------|----------|---------|
| .NET | 10.0 | Runtime |
| ASP.NET Core MVC | 10.0 | Framework |
| C# | 13 | Ngôn ngữ lập trình |
| HTML5 | - | Markup |
| Bootstrap | 5.x | UI Framework |
| JavaScript | ES6 | Validation & Preview |

---

## 💡 Lưu ý quan trọng

### Dữ liệu hiện tại
- Lưu trong **Static List** (sẽ mất khi restart ứng dụng)
- Để persistent, cần thêm **Database**

### Bảo mật (Production)
- ⚠️ Cần thêm **Authentication** (Login)
- ⚠️ Cần thêm **Authorization** (Phân quyền)
- ⚠️ Cần quét **Virus** cho file tải lên
- ⚠️ Sử dụng **HTTPS/SSL** trong production

### Hiệu suất
- Tối ưu hơn: Compress hình ảnh
- Tối ưu hơn: Pagination cho danh sách lớn
- Tối ưu hơn: Cache ảnh

---

## ✅ Kết luận

Bài tập đã hoàn thành đầy đủ tất cả yêu cầu:

✅ **Upload file:** Hỗ trợ upload 1 hoặc nhiều ảnh
✅ **Lưu ảnh:** Lưu vào thư mục `wwwroot/uploads/`
✅ **Xác thực:** Chỉ chấp nhận JPG/PNG, báo lỗi file khác
✅ **Hiển thị:** Danh sách sản phẩm với Tên, Giá, Hình ảnh
✅ **Giao diện:** Thân thiện, responsive, dễ sử dụng
✅ **Build:** Không lỗi, chạy thành công

---

**Tác giả:** GitHub Copilot
**Ngày:** 2026-06-15
**Framework:** ASP.NET Core MVC 10.0

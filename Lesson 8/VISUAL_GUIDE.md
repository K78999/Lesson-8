# 📺 VISUAL GUIDE - Giao diện & Luồng dữ liệu

## 🎨 Giao diện chính

### 1️⃣ TRANG CHỦ (Home)
```
┌─────────────────────────────────────────────┐
│                                             │
│              🏠 WELCOME                    │
│       Learn about ASP.NET Core              │
│                                             │
│     ┌───────────────────────────────┐      │
│     │  📦 Quản lý sản phẩm          │      │
│     │                               │      │
│     │  [➜ Xem danh sách sản phẩm]  │      │
│     └───────────────────────────────┘      │
│                                             │
└─────────────────────────────────────────────┘
```

---

### 2️⃣ DANH SÁCH SẢN PHẨM (Index)
```
┌─────────────────────────────────────────────────────────┐
│  📦 DANH SÁCH SẢN PHẨM                                  │
│  [+ Thêm sản phẩm mới]                                  │
├─────────────────────────────────────────────────────────┤
│ Hình ảnh │ Tên sản phẩm │ Giá (VNĐ) │ Ngày │ Hành động │
├─────────────────────────────────────────────────────────┤
│  [IMG]   │ Sản phẩm 1   │ 100,000  │ 15/6 │[✏️][🗑️]  │
├─────────────────────────────────────────────────────────┤
│  [IMG]   │ Sản phẩm 2   │ 250,000  │ 15/6 │[✏️][🗑️]  │
├─────────────────────────────────────────────────────────┤
│  [IMG]   │ Sản phẩm 3   │ 500,000  │ 15/6 │[✏️][🗑️]  │
└─────────────────────────────────────────────────────────┘
```

---

### 3️⃣ FORM THÊM SẢN PHẨM (Create)
```
┌──────────────────────────────────────────────────────┐
│                                                      │
│     📝 THÊM SẢN PHẨM MỚI                             │
│                                                      │
│  Tên sản phẩm * : [________________]                │
│  Giá (VNĐ) *    : [________________]                │
│                                                      │
│  Hình ảnh * : [Chọn file...] (JPG/PNG, 5MB max)    │
│                                                      │
│  ✅ Các tệp được chọn:                              │
│     ✓ product1.jpg - 256 KB                          │
│     ✓ product2.png - 512 KB                          │
│                                                      │
│  📸 Preview:                                         │
│     ┌──────────┐  ┌──────────┐                       │
│     │ product1 │  │ product2 │                       │
│     │  .jpg    │  │  .png    │                       │
│     └──────────┘  └──────────┘                       │
│                                                      │
│  [💾 Lưu sản phẩm]  [◄ Quay lại]                    │
│                                                      │
└──────────────────────────────────────────────────────┘
```

---

### 4️⃣ FORM CHỈNH SỬA (Edit)
```
┌──────────────────────────────────────────────────────┐
│                                                      │
│     ✏️ CHỈNH SỬA SẢN PHẨM                            │
│                                                      │
│  Tên sản phẩm *  : [Sản phẩm 1______]               │
│  Giá (VNĐ) *     : [100000_________]                │
│                                                      │
│  Hình ảnh hiện tại:                                  │
│     ┌──────────┐                                     │
│     │          │                                     │
│     │  [IMG]   │                                     │
│     │          │                                     │
│     └──────────┘                                     │
│                                                      │
│  Cập nhật hình ảnh (tùy chọn):                      │
│     [Chọn file...]                                   │
│                                                      │
│  [💾 Cập nhật]  [◄ Quay lại]                        │
│                                                      │
└──────────────────────────────────────────────────────┘
```

---

### 5️⃣ FORM XÁC NHẬN XÓA (Delete)
```
┌──────────────────────────────────────────────────────┐
│                                                      │
│     ⚠️ XÁC NHẬN XÓA SẢN PHẨM                          │
│                                                      │
│  Bạn có chắc chắn muốn xóa                          │
│  sản phẩm "Sản phẩm 1" không?                        │
│                                                      │
│  Hình ảnh:                                           │
│     ┌──────────┐                                     │
│     │  [IMG]   │                                     │
│     └──────────┘                                     │
│                                                      │
│  Thông tin:                                          │
│  • Tên: Sản phẩm 1                                   │
│  • Giá: 100,000 VNĐ                                  │
│  • Ngày tạo: 15/06/2026 22:51                        │
│                                                      │
│  ⛔ Lưu ý: Thao tác này không thể hoàn tác!          │
│                                                      │
│  [🗑️ Xóa sản phẩm]  [◄ Quay lại]                    │
│                                                      │
└──────────────────────────────────────────────────────┘
```

---

## 🔄 LUỒNG DỮ LIỆU

### Upload & Lưu trữ
```
┌─────────────────────────────────────────────────────┐
│  1. Chọn file từ máy tính                            │
│     └─> Browser: select file dialog                  │
│                                                      │
│  2. JavaScript validation                            │
│     └─> Kiểm tra loại, kích thước                   │
│     └─> Hiển thị preview                            │
│                                                      │
│  3. Submit form (HTTP POST)                          │
│     └─> Form data + file bytes → Server             │
│                                                      │
│  4. Server-side validation                           │
│     └─> Kiểm tra MIME type                          │
│     └─> Kiểm tra kích thước                         │
│     └─> Nếu sai → Báo lỗi response                  │
│                                                      │
│  5. Lưu file                                         │
│     └─> Generate unique filename (GUID)             │
│     └─> Lưu vào: wwwroot/uploads/{filename}         │
│                                                      │
│  6. Lưu database                                     │
│     └─> Product object với ImagePath                │
│     └─> Thêm vào List<Product>                      │
│                                                      │
│  7. Redirect                                         │
│     └─> Quay về danh sách → Hiển thị sản phẩm mới  │
└─────────────────────────────────────────────────────┘
```

### Hiển thị danh sách
```
┌─────────────────────────────────────────────────────┐
│  1. Request: GET /Product/Index                      │
│     └─> Controller.Index()                           │
│                                                      │
│  2. Lấy dữ liệu                                      │
│     └─> Products.ToList() từ memory                  │
│                                                      │
│  3. Pass vào View                                    │
│     └─> View(products)                              │
│                                                      │
│  4. Render HTML                                      │
│     └─> Foreach product in Model                    │
│     └─> Hiển thị: Hình ảnh | Tên | Giá | ...      │
│                                                      │
│  5. Response HTML                                    │
│     └─> Browser render trang                        │
└─────────────────────────────────────────────────────┘
```

---

## 📊 DATA MODEL

```
Product
├── Id : int
│   └─ Mã định danh (auto-increment)
│
├── Name : string
│   └─ Tên sản phẩm (bắt buộc)
│
├── Price : decimal
│   └─ Giá sản phẩm (> 0)
│
├── ImagePath : string
│   └─ Hình ảnh chính (/uploads/....jpg)
│
├── ImagePaths : List<string>
│   └─ Danh sách ảnh (/uploads/....jpg, /uploads/....png)
│
└── CreatedDate : DateTime
	└─ Ngày tạo sản phẩm
```

---

## 🎯 VALIDATION LOGIC

### Frontend (JavaScript)
```
┌─────────────────────────────────────────┐
│  User chọn file                          │
│  ↓                                       │
│  Kiểm tra MIME type                     │
│  ├─> image/jpeg ? ✅                    │
│  ├─> image/png ? ✅                     │
│  └─> Khác ? ❌ Báo lỗi                  │
│  ↓                                       │
│  Kiểm tra kích thước                    │
│  ├─> ≤ 5MB ? ✅                         │
│  └─> > 5MB ? ❌ Báo lỗi                 │
│  ↓                                       │
│  Hiển thị preview                        │
│  ↓                                       │
│  User submit form                        │
└─────────────────────────────────────────┘
```

### Backend (C#)
```
┌──────────────────────────────────────────┐
│  Server nhận file                        │
│  ↓                                       │
│  Kiểm tra:.ext (.jpg, .png)            │
│  ├─> Có ? ✅                            │
│  └─> Không ? ❌ HTTP 400                │
│  ↓                                       │
│  Kiểm tra ContentType (MIME)            │
│  ├─> image/jpeg ? ✅                    │
│  ├─> image/png ? ✅                     │
│  └─> Khác ? ❌ HTTP 400                 │
│  ↓                                       │
│  Kiểm tra file.Length                   │
│  ├─> ≤ 5MB ? ✅                         │
│  └─> > 5MB ? ❌ HTTP 413                │
│  ↓                                       │
│  Validation OK → Lưu file                │
└──────────────────────────────────────────┘
```

---

## 📂 FILE STORAGE

```
wwwroot/
└── uploads/
	├── d5a3c8b1-2f14-4e9c-a1b2-3c4d5e6f7g8h.jpg
	├── e6b4d9c2-3g25-5f0d-b2c3-4d5e6f7g8h9i.png
	├── f7c5e0d3-4h36-6g1e-c3d4-5e6f7g8h9i0j.jpg
	├── g8d6f1e4-5i47-7h2f-d4e5-6f7g8h9i0j1k.png
	└── ...

URL: /uploads/{filename}
Example: /uploads/d5a3c8b1-2f14-4e9c-a1b2-3c4d5e6f7g8h.jpg
```

---

## 🔗 NAVIGATION FLOW

```
	┌─────────────────────────────────────────┐
	│  🌐 TRANG CHỦ (Home/Index)              │
	│  • Link: "Xem danh sách sản phẩm"      │
	└─────────────────────────────────────────┘
					 │
					 ↓
	┌─────────────────────────────────────────┐
	│  📦 DANH SÁCH SẢN PHẨM (Product/Index) │
	│  • Link: "+ Thêm sản phẩm mới"         │
	│  • Link: "Edit" (trên từng sản phẩm)   │
	│  • Link: "Delete" (trên từng sản phẩm) │
	└─────────────────────────────────────────┘
		   ↙           ↓             ↘
		  /            │              \
		 ↙             ↓               ↘
	[CREATE]      [INDEX]          [EDIT/DELETE]
		│             │                  │
		↓             ↓                  ↓
	Form Thêm   Hiển thị      Form Sửa/Xác nhận
		│             ↑                  │
		│             │                  │
		└─────────────┼──────────────────┘
					  │
				  Quay lại
					  │
					  ↓
				  POST → Redirect
```

---

## ✨ KEY FEATURES MAP

```
PRODUCT MODULE
│
├── ✅ CREATE (Thêm)
│   ├─ Form input: Name, Price
│   ├─ File upload: (1 hoặc nhiều)
│   ├─ Validation: Type, Size
│   └─ Action: POST /Product/Create
│
├── ✅ READ (Xem)
│   ├─ Danh sách bảng
│   ├─ Hiển thị: Hình | Tên | Giá
│   ├─ Thumbnail: 80x80px
│   └─ Action: GET /Product/Index
│
├── ✅ UPDATE (Sửa)
│   ├─ Form edit: Name, Price
│   ├─ Hiển thị ảnh cũ
│   ├─ Upload ảnh mới (tùy chọn)
│   └─ Action: POST /Product/Edit/{id}
│
└── ✅ DELETE (Xóa)
	├─ Xác nhận trước xóa
	├─ Hiển thị thông tin sản phẩm
	└─ Action: POST /Product/Delete/{id}
```

---

## 📈 PERFORMANCE FLOW

```
User Request
	│
	├─→ Routing
	│   └─→ ProductController
	│
	├─→ Action Method
	│   ├─→ Validation
	│   ├─→ File Processing
	│   └─→ Data Storage
	│
	├─→ View Rendering
	│   ├─→ Model binding
	│   └─→ HTML generation
	│
	└─→ Response
		└─→ User Browser
```

---

✅ **Visual Guide Complete!**

Một dự án ASP.NET Core MVC 10.0 với chức năng quản lý sản phẩm đầy đủ!

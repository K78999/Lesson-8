# 🚀 Quick Start Guide - Quản lý sản phẩm

## 1️⃣ Chạy ứng dụng

```bash
# Terminal PowerShell
cd "E:\Congngheweb\Lesson 8\Lesson 8"
dotnet run
```

**Truy cập:** `https://localhost:7xxx` hoặc `http://localhost:5xxx`

---

## 2️⃣ Menu chính

- 🏠 **Home (trang chủ):** Click "Xem danh sách sản phẩm"
- 📦 **Products:** Quản lý sản phẩm

---

## 3️⃣ Thêm sản phẩm

| Bước | Hành động |
|------|----------|
| 1 | Click "Thêm sản phẩm mới" |
| 2 | Nhập **Tên** sản phẩm |
| 3 | Nhập **Giá** (VNĐ) |
| 4 | Chọn hình ảnh **JPG** hoặc **PNG** (1 hoặc nhiều) |
| 5 | Click "Lưu sản phẩm" |

---

## 4️⃣ Upload ảnh - Quy tắc

| Điều kiện | Kết quả |
|-----------|--------|
| ✅ JPG, JPEG, PNG | **Tải lên được** |
| ❌ GIF, BMP, TIFF | **Báo lỗi** |
| ❌ > 5MB | **Quá lớn** |
| ✅ < 5MB | **OK** |

---

## 5️⃣ Danh sách sản phẩm - Hiển thị

```
┌─────────────────────────────────────────────────────┐
│ Hình ảnh │ Tên | Giá | Ngày | Sửa | Xóa            │
├─────────────────────────────────────────────────────┤
│ [Image] │ Sản phẩm 1 | 100,000 | 15/06 | [✏️] | [🗑️] │
├─────────────────────────────────────────────────────┤
│ [Image] │ Sản phẩm 2 | 250,000 | 15/06 | [✏️] | [🗑️] │
└─────────────────────────────────────────────────────┘
```

---

## 6️⃣ Thư mục lưu ảnh

```
📂 wwwroot/uploads/
   ├── d5a3c8b1-2f14-4e9c-a1b2-3c4d5e6f7g8h.jpg
   ├── e6b4d9c2-3g25-5f0d-b2c3-4d5e6f7g8h9i.png
   └── ... (tất cả ảnh tải lên)
```

---

## 7️⃣ Lỗi phổ biến & Cách khắc phục

| Lỗi | Nguyên nhân | Cách khắc phục |
|-----|-----------|-----------------|
| "Tên bắt buộc" | Tên trống | Nhập tên sản phẩm |
| "Giá phải >0" | Giá <= 0 | Nhập giá > 0 |
| "Chọn ảnh" | Không chọn file | Chọn ít nhất 1 ảnh |
| "Chỉ hỗ trợ JPG/PNG" | File sai định dạng | Dùng JPG hoặc PNG |
| "Quá lớn (>5MB)" | File file quá nặng | Dùng ảnh nhỏ hơn 5MB |

---

## 8️⃣ Tệp thay đổi / Tạo mới

```
✨ Tạo mới:
- Models/Product.cs
- Controllers/ProductController.cs
- Views/Product/Index.cshtml
- Views/Product/Create.cshtml
- Views/Product/Edit.cshtml
- Views/Product/Delete.cshtml
- wwwroot/uploads/ (folder)

🔄 Cập nhật:
- Views/Home/Index.cshtml (thêm link "Xem danh sách sản phẩm")

📚 Tài liệu:
- HUONG_DAN_SU_DUNG.md
- BAI_TAP_CHI_TIET.md
```

---

## 9️⃣ Build Project

```bash
# Compile
dotnet build

# Build Publish
dotnet publish -c Release -o ./publish
```

---

## 🔟 Troubleshooting

**Lỗi: Port đã sử dụng**
```bash
# Thay đổi port trong launchSettings.json
# Hoặc kill process
netstat -ano | findstr :5000
taskkill /PID <PID> /F
```

**Lỗi: File không upload được**
- Kiểm tra quyền thư mục `wwwroot/uploads/`
- Đảm bảo ứng dụng có quyền ghi

---

## 📞 Hỗ trợ

**Tài liệu chi tiết:** `BAI_TAP_CHI_TIET.md`
**Hướng dẫn sử dụng:** `HUONG_DAN_SU_DUNG.md`

---

✅ **Bài tập hoàn thành!** Tất cả yêu cầu đã được thực hiện.

# Hướng dẫn sử dụng chức năng Tải lên hình ảnh sản phẩm

## Tổng quan

Ứng dụng đã được cấu hình để cho phép người dùng:
- ✅ Tải lên hình ảnh sản phẩm (1 hoặc nhiều ảnh)
- ✅ Chỉ chấp nhận file JPG/PNG
- ✅ Hiển thị danh sách sản phẩm với Tên, Giá, và Hình ảnh
- ✅ Chỉnh sửa và xóa sản phẩm

## Cấu trúc thư mục được tạo

```
Lesson 8/
├── Models/
│   └── Product.cs              # Model cho sản phẩm
├── Controllers/
│   └── ProductController.cs    # Controller quản lý sản phẩm
├── Views/
│   └── Product/                # Folder view cho Product
│       ├── Index.cshtml        # Danh sách sản phẩm
│       ├── Create.cshtml       # Form thêm sản phẩm mới
│       ├── Edit.cshtml         # Form chỉnh sửa sản phẩm
│       └── Delete.cshtml       # Trang xác nhận xóa
└── wwwroot/
	└── uploads/                # Folder lưu trữ hình ảnh
```

## Tính năng chi tiết

### 1. Product Model
```csharp
- Id: Mã định danh sản phẩm
- Name: Tên sản phẩm (bắt buộc)
- Price: Giá sản phẩm (bắt buộc, >0)
- ImagePath: Đường dẫn hình ảnh chính
- ImagePaths: Danh sách các đường dẫn hình ảnh (hỗ trợ nhiều ảnh)
- CreatedDate: Ngày tạo sản phẩm
```

### 2. Xác thực tệp tải lên
- ✅ Kiểm tra phần mở rộng: .jpg, .jpeg, .png
- ✅ Kiểm tra MIME type: image/jpeg, image/png
- ✅ Giới hạn kích thước: 5MB/tệp
- ✅ Báo lỗi chi tiết nếu tệp không hợp lệ

### 3. Giao diện người dùng
- **Index.cshtml**: Hiển thị bảng sản phẩm với:
  - Hình ảnh thumbnail (80x80px)
  - Tên sản phẩm
  - Giá (định dạng số)
  - Ngày tạo
  - Nút Sửa/Xóa

- **Create.cshtml**: Form thêm sản phẩm với:
  - Input tên sản phẩm
  - Input giá
  - Chọn file hình ảnh (multiple)
  - Preview hình ảnh trước khi tải lên
  - Danh sách các tệp được chọn

- **Edit.cshtml**: Form chỉnh sửa với:
  - Hiển thị hình ảnh hiện tại
  - Option cập nhật hình ảnh mới (tùy chọn)

## Cách sử dụng

### 1. Truy cập ứng dụng
- Mở: `https://localhost:xxxx` hoặc `http://localhost:xxxx`
- Click vào "Xem danh sách sản phẩm" trên trang chủ

### 2. Thêm sản phẩm mới
1. Từ danh sách sản phẩm, click nút "Thêm sản phẩm mới"
2. Nhập Tên sản phẩm
3. Nhập Giá (VNĐ)
4. Chọn 1 hoặc nhiều file hình ảnh (JPG/PNG)
5. Preview sẽ hiển thị tự động
6. Click "Lưu sản phẩm"

### 3. Chỉnh sửa sản phẩm
1. Từ danh sách, click nút "Sửa"
2. Cập nhật thông tin sản phẩm
3. Tùy chọn: Chọn hình ảnh mới để thay thế
4. Click "Cập nhật sản phẩm"

### 4. Xóa sản phẩm
1. Từ danh sách, click nút "Xóa"
2. Xác nhận thao tác xóa
3. Sản phẩm sẽ bị xóa vĩnh viễn

## Đường dẫn URL

```
GET    /Product/Index            - Danh sách sản phẩm
GET    /Product/Create           - Form thêm sản phẩm
POST   /Product/Create           - Lưu sản phẩm mới
GET    /Product/Edit/5           - Form chỉnh sửa
POST   /Product/Edit/5           - Cập nhật sản phẩm
GET    /Product/Delete/5         - Xác nhận xóa
POST   /Product/Delete/5         - Xóa sản phẩm
```

## Xác thực dữ liệu

### Frontend (JavaScript)
- Kiểm tra loại file trước khi tải
- Hiển thị lỗi ngay lập tức
- Preview hình ảnh

### Backend (C#)
- Xác thực độ dài tệp
- Kiểm tra MIME type
- Kiểm tra phần mở rộng
- Báo lỗi chi tiết

## Lưu trữ tệp

- Tất cả hình ảnh được lưu trong: `wwwroot/uploads/`
- Tên tệp được tạo ngẫu nhiên: `{GUID}.{extension}`
- Đường dẫn trong database: `/uploads/{filename}`

## Lưu ý quan trọng

1. **Lưu trữ**: Hiện tại dữ liệu được lưu trong memory static list. Để persistent, cần:
   - Thêm database (SQL Server, SQLite, etc.)
   - Sử dụng Entity Framework Core

2. **Bảo mật**: Trong production, cần:
   - Xác thực người dùng (Authentication)
   - Phân quyền (Authorization)
   - Quét virus cho tệp tải lên
   - SSL/HTTPS

3. **Hiệu suất**: Với dữ liệu lớn:
   - Compress hình ảnh
   - Pagination cho danh sách
   - Cache ảnh

## Yêu cầu đã thực hiện

✅ Cho phép upload hình sản phẩm (1 hoặc nhiều ảnh)
✅ Chỉ chấp nhận file jpg/png
✅ Báo lỗi khi file không hợp lệ
✅ Hiển thị danh sách sản phẩm với Tên, Giá, Hình ảnh
✅ Giao diện thân thiện, responsive
✅ Build thành công không có lỗi

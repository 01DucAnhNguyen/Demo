# Ý tưởng : QUẢN LÍ NHÀ HÀNG
https://www.academia.edu/36158240/Qu%E1%BA%A3n_l%C3%BD_nh%C3%A0_h%C3%A0ng
  1. Nguyễn Đức Anh   
  2. Hoàng Xuân Cường 
  3. Khuất Phú Kiên 
  4. Vũ Minh Phong

## Xác định yêu cầu bài toán khách hàng đặt ra:
### Phần "Quản lí nhà hàng" có thể dành cho nhiều người sử dụng khác nhau, bao gồm:
- Chủ sở hữu nhà hàng: Chủ sở hữu nhà hàng cần một hệ thống quản lí để theo dõi và điều hành các hoạt động của nhà hàng. Họ có thể sử dụng phần mềm quản lý nhà hàng để kiểm soát doanh thu, theo dõi kho hàng, quản lý nhân viên, thu chi, lợi nhuận.
- Quản lý: Người quản lý nhà hàng có nhiệm vụ giám sát hoạt động hàng ngày của nhà hàng, bao gồm quản lý nhân viên, lập kế hoạch làm việc, xử lý sự cố, và bảo đảm rằng mọi hoạt động diễn ra trơn tru.
- Nhân viên: Nhân viên trong nhà hàng, bao gồm đầu bếp, phục vụ, thu ngân và cần một hệ thống quản lý để ghi nhận lịch làm việc, đặt món, quản lý đơn hàng.
- Khách hàng: Một phần của hệ thống quản lý nhà hàng cũng có thể cung cấp cơ chế đặt bàn trực tuyến, đặt món trước và theo dõi lịch sử đơn hàng cho khách hàng.
- Quản lí danh sách món ăn(Menu): Quản lí món ăn theo nhóm, hiển thị hình ảnh món ăn, giá món ăn.


### Hệ thống quản lí nhà hàng được sử dụng để quản lý và điều hành các hoạt động hàng ngày của một nhà hàng. Nó cung cấp một loạt các chức năng và tính năng giúp tối ưu hóa quản lý nhà hàng, cải thiện trải nghiệm khách hàng và tăng hiệu suất kinh doanh. Dưới đây là một số mục đích chính của hệ thống quản lí nhà hàng:
- Quản lý đặt bàn: Hệ thống quản lí nhà hàng cho phép quản lý số lượng bàn còn trống, đang phục vụ. Nhân viên có thể dễ dàng đặt món cho khách hàng và đặt bàn cho khách hàng và theo dõi.
- Quản lý thực đơn( menu ): Hỗ trợ tạo, chỉnh sửa và quản lý thực đơn. Cập nhật thông tin về món ăn, giá cả, khả dụng và các chi tiết liên quan khác.
- Quản lý nhân viên: Lương, quyền hạn và hiệu suất của nhân viên. Giúp quản lý nhân sự hiệu quả và đảm bảo hoạt động trơn tru.
- Quản lý kho hàng: Theo dõi tồn kho, đặt hàng mới, kiểm tra nguồn cung cấp và quản lý hàng tồn kho.
- Thanh toán : Ghi nhận giao dịch bán hàng, xử lý thanh toán, quản lý hóa đơn và lập báo cáo tài chính.
- Quản lý hóa đơn: Ghi nhận lại các hóa đơn, chi tiết thực đơn có trong hóa đơn, tổng tiền, phương thức thanh toán, ...
- Phân tích dữ liệu: Tạo báo cáo về doanh thu, lợi nhuận và phân tích dữ liệu để đưa ra quyết định kinh doanh thông minh.

# Content Restaurant Manager:
- Đăng nhập phân quyền: Quản lí, nhân viên (2)
- Quản lý nhân viên: Tính thời gian làm việc, lương cho nhân viên, Nhân viên lễ tân, Nhân viên phục vụ, Đầu bếp.(1)
- Quản lý hàng hoá: Giá nhập, ngày nhập, giá bán(2)
- Menu: Hiển thị hình ảnh món ăn, giá món(2, 3)
- Quản lý bàn: Tổng số lượng bàn của nhà hàng, tình trạng còn bàn, hết bàn, thông tin từng bàn đang phục vụ(4)
- Báo cáo doanh thu nhà hàng: Tiền nhập hàng, tiền lương cho nhân viên, tiền thu nhập của nhà hàng, các chi phí khác, doanh thu của nhà hàng tháng, năm(1, 4)
- Quản lí đơn hàng: Thông tin chi  tiết hóa đơn, tổng tiền, hình thức thanh toán(3)

  # Database Design:
- tblNhanVien: mã nhân viên, họ tên, sđt, địa chỉ, tk, mk, ảnh.
- tblHangHoa: mã hàng, tên hàng, giá bán, số lượng
- tblHoaDon: mã hóa đơn, mã nhân viên, ngày lên đơn, tổng tiền, phương thức thanh toán
- tblChiTietHoaDon: mã hóa đơn, mã hàng, số lượng
- tblNhapHang: mã hàng nhập, số lượng nhập, giá nhập, ngày nhập
- tblMenu: mã menu, mã hàng





// Lấy tất cả các liên kết có class là 'nav-link'
var navLinks = document.querySelectorAll('.nav-link');

// Lặp qua từng liên kết và thêm sự kiện click
navLinks.forEach(function (link) {
    link.addEventListener('click', function (event) {
        event.preventDefault(); // Ngăn chặn hành động mặc định của liên kết

        // Xóa lớp 'active' từ tất cả các liên kết
        navLinks.forEach(function (item) {
            item.classList.add('collapsed');
        });

        // Thêm lớp 'active' vào liên kết được click
        this.classList.remove('collapsed');

        // Lấy href của liên kết để chuyển đến action tương ứng
        var url = this.getAttribute('href');
        // Chuyển đến URL
        window.location.href = url;
    });
});
const io = require('socket.io-client');

// Kết nối tới server Socket.IO trên cổng 8000
const socket = io('http://192.168.1.92:8000');

// Hàm để tạo dữ liệu ngẫu nhiên cho sự kiện 'status-machine'
function generateRandomStatus() {
  return {
    id: Math.floor(Math.random() * 1000),  // ID ngẫu nhiên từ 0 đến 999
    status: Math.random() > 0.5 ? 'active' : 'inactive',  // Trạng thái ngẫu nhiên
    timestamp: new Date().toISOString(),  // Thời gian hiện tại
  };
}

// Khi client kết nối thành công tới server
socket.on('connect', () => {
  console.log('Connected to server on port 8000');

  setInterval(() => {
    const randomStatus = generateRandomStatus();

    // Gửi event 'status-machine' với dữ liệu và một hàm callback
    socket.emit('change-status', randomStatus, (response) => {
      console.log('Received response from server:', response);
      // Thực hiện các hành động khác tại đây nếu cần
    });
  }, 5000);
}); // Mỗi 5 giây gửi 1 lần


// Xử lý sự kiện ngắt kết nối
socket.on('disconnect', () => {
  console.log('Disconnected from server');
});

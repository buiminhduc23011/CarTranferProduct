const express = require('express');
const http = require('http');
const socketIO = require('socket.io');
const fs = require('fs');
const path = require('path');

// Biến để bật/tắt log
let enableLogging = true; // Đặt thành false nếu muốn tắt log

// Ghi dữ liệu vào file theo ngày
function logToFile(message) {
  if (!enableLogging) return; // Nếu log bị tắt, không ghi log

  const timestamp = new Date().toISOString(); // Thời gian cho từng log
  const logDate = new Date().toISOString().slice(0, 10); // Ngày (yyyy-mm-dd)
  const logFileName = `log_${logDate}.txt`; // Tên file log theo ngày
  const logFilePath = path.join(__dirname, logFileName); // Đường dẫn file log

  // Chuyển dữ liệu thành chuỗi JSON để ghi đúng định dạng
  const logMessage = typeof message === 'object' ? JSON.stringify(message, null, 2) : message;

  fs.appendFile(logFilePath, `${timestamp} - ${logMessage}\n`, (err) => {
    if (err) throw err;
  });
}

// Thay thế console.log để vừa ghi log ra console, vừa ghi vào file
const originalConsoleLog = console.log;
console.log = function (...args) {
  const message = args.map(arg => (typeof arg === 'object' ? JSON.stringify(arg, null, 2) : arg)).join(' ');
  originalConsoleLog(...args); // In ra console
  logToFile(message); // Ghi vào file nếu enableLogging = true
};

// Tạo server lắng nghe trên cổng 8000
const appListen = express();
const serverListen = http.createServer(appListen);
const ioListen = socketIO(serverListen);

serverListen.listen(8000, () => {
  console.log('Server Transfer Data Is Start');
});

// Cổng 8000: Lắng nghe kết nối để gửi data
ioListen.on('connection', (socket) => {
  console.log('IOT Connected');

  socket.on('change-status', async (data, callback) => {
    console.log('Received data from IOT:', data);
    let response = await forwardDataToClient(data);
    callback(response);
  });

  socket.on('disconnect', () => {
    console.log('IOT disconnect');
  });
});

const io = require('socket.io-client');

// Kết nối tới server Socket.IO trên cổng 8000
 const socket = io('http://192.168.1.92:3000');
//const socket = io('http://172.21.80.47:4444');
// Khi client kết nối thành công tới server
socket.on('connect', () => {
  console.log('Connected to Server');
});

function forwardDataToClient(data) {
  return new Promise((resolve, reject) => {
    socket.emit('change-status', data, (response) => {
      if (response) {
        console.log('Update data to server:', response);
        resolve(response);  // Trả về response khi có kết quả
      } else {
        reject('No response from server');  // Báo lỗi nếu không nhận được phản hồi
      }
    });
  });
}

socket.on('disconnect', () => {
  console.log('Disconnected from server');
});

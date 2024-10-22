const express = require('express');
const http = require('http');
const socketIO = require('socket.io');

// Tạo server lắng nghe trên cổng 8000
const appListen = express();
const serverListen = http.createServer(appListen);
const ioListen = socketIO(serverListen);

serverListen.listen(3000, () => {
    console.log('Socket.IO Server Test is listening on port 3000');
});

// Cổng 8000: Lắng nghe kết nối để gửi data
ioListen.on('connection', (socket) => {
    console.log('Client connected on port 3000');

    // Lắng nghe sự kiện 'status-update' từ cổng 3000
    socket.on('change-status',  async (data, callback)  => {
        console.log('Received data from port 3000:', data);
        callback(data);
    });

    socket.on('disconnect', () => {
        console.log('Client disconnected from port 3000');
    });
});

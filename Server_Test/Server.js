// server.js
const fs = require("fs");

const express = require("express");
const http = require("http");
const socketIO = require("socket.io");

const app = express();
const server = http.createServer(app);
const io = socketIO(server);

const PORT = process.env.PORT || 5000;


io.on("connection", (socket) => {
  console.log("Client connected");
  socket.emit("message", "Welcome to the server!");

  socket.on("sendMessage", (message) => {
    io.emit("message", message);
  });

  socket.on("disconnect", () => {
    console.log("Client disconnected");
  });
  socket.on("connect-machine", (data) => {
    console.log("IoT device connected:", data);
  });

  socket.on("machine-status", (data) => {
    console.log("machine-status:", data);
  });
});


server.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);

});

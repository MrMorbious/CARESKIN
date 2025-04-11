# Sử dụng Node.js phiên bản 18 với Alpine
FROM node:18-alpine

# Thiết lập thư mục làm việc
WORKDIR /app

# Copy package.json để tối ưu cache
COPY package*.json ./

# Cài đặt dependencies (bao gồm cả devDependencies)
RUN npm install

# Copy toàn bộ mã nguồn vào container
COPY . .

# Mở cổng Vite
EXPOSE 5173

# Chạy ứng dụng với --host để container có thể truy cập được
CMD ["npm", "run", "dev", "--", "--host", "0.0.0.0"]

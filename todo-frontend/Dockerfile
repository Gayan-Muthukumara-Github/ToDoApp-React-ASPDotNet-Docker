# Use Node.js LTS image
FROM node:18-alpine

# Set working directory
WORKDIR /app

# Copy files
COPY package.json ./
COPY package-lock.json ./
RUN npm install

COPY . .

# Build the app
RUN npm run build

# Use NGINX to serve the build
FROM nginx:alpine
COPY --from=0 /app/build /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

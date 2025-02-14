# Stage 1: Build the Angular application
FROM node:16 AS build
WORKDIR /app/company-spa

# Copy package files from the company-spa folder (adjust the path as needed)
COPY company-spa/package*.json ./
RUN npm install

# Copy the rest of the source code from the company-spa folder
COPY company-spa/ ./

# Build the app in production mode (adjust the outputPath if necessary)
RUN npm run build -- --prod

# Stage 2: Serve the built app with NGINX
FROM nginx:alpine

# Remove the default NGINX content
RUN rm -rf /usr/share/nginx/html/*

# Copy the Angular build output to NGINX's html folder
COPY --from=build /app/company-spa/dist/company-spa /usr/share/nginx/html

# Copy our custom NGINX configuration file into the container.
# Make sure you have a 'default.conf' file in the same directory as your Dockerfile.
COPY company-spa/default.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

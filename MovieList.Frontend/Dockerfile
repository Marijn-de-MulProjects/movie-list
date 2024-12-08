FROM arm32v7/node:16 AS build  
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build

FROM arm32v7/nginx:alpine  
COPY --from=build /app/build /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

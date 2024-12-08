FROM arm64v8/node:16-alpine as build

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build

FROM arm64v8/node:16-alpine as serve

WORKDIR /app

COPY --from=build /app/dist /app/dist

RUN npm install -g vite

EXPOSE 80

CMD ["vite", "preview", "--port", "80", "--host", "0.0.0.0"]

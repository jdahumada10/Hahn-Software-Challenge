#stage 1
FROM node:latest as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --omit=dev
#stage 2
FROM nginx:alpine
COPY --from=node /app/dist/hrsoftware-management-web-app /usr/share/nginx/html
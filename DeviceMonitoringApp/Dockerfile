FROM node:24.14.0-alpine AS build
WORKDIR /app

COPY package*.json ./
RUN npm ci

RUN node --version && npm --version && npx ng version

COPY . .

RUN npx ng build --configuration production

FROM nginx:stable-alpine AS final

COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist/DeviceMonitoringApp/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
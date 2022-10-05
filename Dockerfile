FROM node:14-alpine as build
WORKDIR /app
ENV NODE_OPTIONS=--max_old_space_size=2048
COPY package.json .
RUN npm i -g @quasar/cli
RUN npm install
COPY . .
RUN quasar build

FROM nginx
COPY --from=build /app/dist/spa /usr/share/nginx/html

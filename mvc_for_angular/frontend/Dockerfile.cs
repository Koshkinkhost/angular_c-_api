//FROM  node:22.10.0-alpine3.20 AS build
//WORKDIR /src
//COPY package.json .
//RUN npm -i
//COPY . . 
//RUN npm run build

//FROM nginx:mainline-alpine3.20-slim AS webserver
//    COPY --from=build /src/dist/browser /usr/share/nginx/html


//FROM node:22.10.0-alpine3.20 AS final
//WORKDIR /app
//COPY --from=build /src/dist/server .
//CMD ["node",".dist/server/server/mjs"]
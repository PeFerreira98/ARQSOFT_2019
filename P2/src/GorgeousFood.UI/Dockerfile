# base image
FROM node:lts-alpine

# Expose PORT 3000 on our virtual machine so we can run our server
EXPOSE 3000

ADD . /app

WORKDIR /app

RUN npm install

CMD ["npm", "start"]
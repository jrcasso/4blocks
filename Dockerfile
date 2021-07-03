# Pull nginx base image
FROM nginx:latest

COPY nginx.conf /etc/nginx/nginx.conf

COPY ./dist /var/www

EXPOSE 80

CMD ["nginx"]

FROM mysql:8

ENV MYSQL_ROOT_PASSWORD password

COPY ./db/init.sql /docker-entrypoint-initdb.d/init.sql

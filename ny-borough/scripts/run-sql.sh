#!/bin/sh

cat insert.sql

PGSQL_EXISTS=$(echo $VCAP_SERVICES | jq '.["postgresql-10-odb"]')

if [ "$MYSQL_EXISTS" = "null" ]; then

   echo "PostgreSQL Service not bound..."

else

    DB_HOST=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.db_host')
    DB_NAME=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.db_name')
    DB_PORT=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.db_port')
    DB_USERNAME=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.username')
    DB_PASSWORD=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.password')

fi

export PGPASSWORD=$DB_PASSWORD
psql -h $DB_HOST -d $DB_NAME -U $DB_USERNAME -w -f insert.sql
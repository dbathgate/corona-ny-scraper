#!/bin/bash

PGSQL_EXISTS=$(echo $VCAP_SERVICES | jq '.["postgresql-10-odb"]')

if [ "$PGSQL_EXISTS" = "null" ]; then

   echo "PostgreSQL Service not bound..."
   echo "Running grana using sqlite..."
   cd ./grafana-6.7.1/; exec ./bin/grafana-server 

else

    DB_HOST=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.db_host')
    DB_NAME=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.db_name')
    DB_PORT=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.db_port')
    DB_USERNAME=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.username')
    DB_PASSWORD=$(echo $VCAP_SERVICES | jq -r '.["postgresql-10-odb"][0].credentials.password')

    cp grafana-template.ini ./grafana-6.7.1/conf/grafana.ini

    sed -i -e "s/%DB_USERNAME%/$DB_USERNAME/g" ./grafana-6.7.1/conf/grafana.ini
    sed -i -e "s/%DB_PORT%/$DB_PORT/g" ./grafana-6.7.1/conf/grafana.ini
    sed -i -e "s/%DB_PASSWORD%/$DB_PASSWORD/g" ./grafana-6.7.1/conf/grafana.ini
    sed -i -e "s/%DB_HOST%/$DB_HOST/g" ./grafana-6.7.1/conf/grafana.ini
    sed -i -e "s/%DB_NAME%/$DB_NAME/g" ./grafana-6.7.1/conf/grafana.ini
    sed -i -e "s/%IP_ADDRESS%/$CF_INSTANCE_INTERNAL_IP/g" ./grafana-6.7.1/conf/grafana.ini

    cd ./grafana-6.7.1/; exec ./bin/grafana-server --config=./conf/grafana.ini

fi
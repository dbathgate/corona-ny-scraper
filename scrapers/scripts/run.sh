#!/bin/sh

echo "Downloading pdf..."
./download-pdf.sh

echo "Converting pdf..."
./convert-pdf.sh

echo "Parsing text..."
./parse-text.sh

echo "Downloading newsday feed..."
./download-newsday.sh

echo "Parsing Json..."
./parse-newsday.sh

echo "Running SQL..."
./run-sql.sh insert.sql
./run-sql.sh insert_deaths.sql
./run-sql.sh insert_hospitalizations.sql
./run-sql.sh insert_newsday.sql
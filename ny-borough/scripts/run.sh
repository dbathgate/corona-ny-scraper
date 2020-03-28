#!/bin/sh

echo "Downloading pdf..."
./download-pdf.sh

echo "Converting pdf..."
./convert-pdf.sh

echo "Parsing text..."
./parse-text.sh

echo "Running SQL..."
./run-sql.sh
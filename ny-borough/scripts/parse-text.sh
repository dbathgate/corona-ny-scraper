#!/bin/sh

file="covid-19-daily-data-summary.txt"
output="insert.sql"

brooklyn=$(cat $file | grep Brooklyn -A 2 | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
manhattan=$(cat $file | grep Manhattan -A 2 | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
queens=$(cat $file | grep Queens -A 2 | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
staten=$(cat $file | grep "Staten Island" -A 2 | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
bronx=$(cat $file | grep "Bronx" -A 2 | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')

export TX=GMT
last_updated=$(date +"%Y-%m-%d %H:%M:%S")

echo "Brooklyn: $brooklyn"
echo "Manhattan: $manhattan"
echo "Queens: $queens"
echo "Staten: $staten"
echo "Bronx: $bronx"

echo "INSERT INTO corona_boroughs (last_updated, brooklyn, manhattan, queens, staten, bronx) values ('$last_updated', $brooklyn, $manhattan, $queens, $staten, $bronx); " > $output
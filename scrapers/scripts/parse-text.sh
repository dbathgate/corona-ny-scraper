#!/bin/sh

file="covid-19-daily-data-summary.txt"
file_deaths="covid-19-daily-data-summary-deaths.txt"
file_hospitalizations="covid-19-daily-data-summary-hospitalizations.txt"

output="insert.sql"
output_deaths="insert_deaths.sql"
output_hospitalizations="insert_hospitalizations.sql"

brooklyn=$(cat $file | grep Brooklyn | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
manhattan=$(cat $file | grep Manhattan | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
queens=$(cat $file | grep Queens| sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
staten=$(cat $file | grep "Staten Island" | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
bronx=$(cat $file | grep "Bronx" | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')

brooklyn_deaths=$(cat $file_deaths | grep Brooklyn | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $4}')
manhattan_deaths=$(cat $file_deaths | grep Manhattan | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $4}')
queens_deaths=$(cat $file_deaths | grep Queens| sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $4}')
staten_deaths=$(cat $file_deaths | grep "Staten Island" | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $4}')
bronx_deaths=$(cat $file_deaths | grep "Bronx" | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $4}')

brooklyn_hospitalizations=$(cat $file_hospitalizations | grep Brooklyn | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
manhattan_hospitalizations=$(cat $file_hospitalizations | grep Manhattan | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
queens_hospitalizations=$(cat $file_hospitalizations | grep Queens| sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
staten_hospitalizations=$(cat $file_hospitalizations | grep "Staten Island" | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')
bronx_hospitalizations=$(cat $file_hospitalizations | grep "Bronx" | sed "s/[^0-9]*//" | tr -d '\n' | awk '{print $1}')

export TZ=GMT
last_updated=$(date +"%Y-%m-%d %H:%M:%S")

echo "Brooklyn: $brooklyn"
echo "Manhattan: $manhattan"
echo "Queens: $queens"
echo "Staten: $staten"
echo "Bronx: $bronx"
echo "--"
echo "Brooklyn Deaths: $brooklyn_deaths"
echo "Manhattan Deaths: $manhattan_deaths"
echo "Queens Deaths: $queens_deaths"
echo "Staten Deaths: $staten_deaths"
echo "Bronx Deaths: $bronx_deaths"
echo "--"
echo "Brooklyn Hospitalizations: $brooklyn_hospitalizations"
echo "Manhattan Hospitalizations: $manhattan_hospitalizations"
echo "Queens Hospitalizations: $queens_hospitalizations"
echo "Staten Hospitalizations: $staten_hospitalizations"
echo "Bronx Hospitalizations: $bronx_hospitalizations"

echo "INSERT INTO corona_boroughs (last_updated, brooklyn, manhattan, queens, staten, bronx) values ('$last_updated', $brooklyn, $manhattan, $queens, $staten, $bronx); " > $output
echo "INSERT INTO corona_borough_deaths (last_updated, brooklyn, manhattan, queens, staten, bronx) values ('$last_updated', $brooklyn_deaths, $manhattan_deaths, $queens_deaths, $staten_deaths, $bronx_deaths); " > $output_deaths
echo "INSERT INTO corona_borough_hospitalizations (last_updated, brooklyn, manhattan, queens, staten, bronx) values ('$last_updated', $brooklyn_hospitalizations, $manhattan_hospitalizations, $queens_hospitalizations, $staten_hospitalizations, $bronx_hospitalizations); " > $output_hospitalizations
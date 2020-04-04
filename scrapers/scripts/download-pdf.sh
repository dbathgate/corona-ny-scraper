#!/bin/sh
set -x

day=$(TZ=America/New_York date +"%m%d%Y")
index=2

status_code=$(curl -Lo covid-19-daily-data-summary.pdf https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-${day}-${index}.pdf -w "%{http_code}")

if [ $status_code = 404 ]; then
    index=1
    status_code=$(curl -Lo covid-19-daily-data-summary.pdf https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-${day}-${index}.pdf -w "%{http_code}")

    if [ $status_code = 404 ]; then
        day=$(TZ=America/New_York date +"%m%d%Y" -d "1 day ago")
        index=2

        status_code=$(curl -Lo covid-19-daily-data-summary.pdf https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-${day}-${index}.pdf -w "%{http_code}")

        if [ $status_code = 404 ]; then
            index=1

            curl -Lo covid-19-daily-data-summary.pdf "https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-${day}-${index}.pdf"
        fi
    fi
fi

day=$(TZ=America/New_York date +"%m%d%Y")
index=2

# deaths
status_code=$(curl -Lo covid-19-daily-data-summary-deaths.pdf https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-deaths-${day}-${index}.pdf -w "%{http_code}")

if [ $status_code = 404 ]; then
    index=1
    status_code=$(curl -Lo covid-19-daily-data-summary-deaths.pdf https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-deaths-${day}-${index}.pdf -w "%{http_code}")

    if [ $status_code = 404 ]; then
        day=$(TZ=America/New_York date +"%m%d%Y" -d "1 day ago")
        index=2

        status_code=$(curl -Lo covid-19-daily-data-summary-deaths.pdf https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-deaths-${day}-${index}.pdf -w "%{http_code}")

        if [ $status_code = 404 ]; then
            index=1

            curl -Lo covid-19-daily-data-summary-deaths.pdf "https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-deaths-${day}-${index}.pdf"
        fi
    fi
fi

day=$(TZ=America/New_York date +"%m%d%Y")
index=2

# hospitalizations
status_code=$(curl -Lo covid-19-daily-data-summary-hospitalizations.pdf https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-hospitalizations-${day}-${index}.pdf -w "%{http_code}")

if [ $status_code = 404 ]; then
    index=1
    status_code=$(curl -Lo covid-19-daily-data-summary-hospitalizations.pdf https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-hospitalizations-${day}-${index}.pdf -w "%{http_code}")

    if [ $status_code = 404 ]; then
        day=$(TZ=America/New_York date +"%m%d%Y" -d "1 day ago")
        index=2

        status_code=$(curl -Lo covid-19-daily-data-summary-hospitalizations.pdf https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-hospitalizations-${day}-${index}.pdf -w "%{http_code}")

        if [ $status_code = 404 ]; then
            index=1

            curl -Lo covid-19-daily-data-summary-hospitalizations.pdf "https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-hospitalizations-${day}-${index}.pdf"
        fi
    fi
fi

#curl https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary.pdf -LO
#curl https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-deaths.pdf -LO
#curl https://www1.nyc.gov/assets/doh/downloads/pdf/imm/covid-19-daily-data-summary-hospitalizations.pdf -LO
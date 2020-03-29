
file="newsday.json"
output="insert_newsday.sql"


suffolk=$(cat $file | jq ".suffolk")
nassau=$(cat $file | jq ".nassau")
nyc=$(cat $file | jq ".nyc")
state=$(cat $file | jq ".state")
newsday_last_updated=$(cat $file | jq -r ".last_updated")

export TZ=GMT
last_updated=$(date +"%Y-%m-%d %H:%M:%S")

echo "Suffolk: $suffolk"
echo "Nassau: $nassau"
echo "Nyc: $nyc"
echo "State: $state"

echo "INSERT INTO corona_ny (last_updated, newsday_last_updated, suffolk, nassau, nyc, state) VALUES ('$last_updated', '$newsday_last_updated', $suffolk, $nassau, $nyc, $state);" > $output
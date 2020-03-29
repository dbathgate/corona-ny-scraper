FROM alpine

RUN apk add poppler-utils curl postgresql jq

ADD scripts/ .

CMD ["./run.sh"]
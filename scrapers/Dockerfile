FROM alpine

RUN apk add poppler-utils curl postgresql jq
RUN apk add --update coreutils

ADD scripts/ .

CMD ["./run.sh"]
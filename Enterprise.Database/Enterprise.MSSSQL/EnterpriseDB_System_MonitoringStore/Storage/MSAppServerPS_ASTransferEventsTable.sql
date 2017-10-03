CREATE PARTITION SCHEME [MSAppServerPS_ASTransferEventsTable]
    AS PARTITION [MSAppServerPF_ASTransferEventsTable]
    TO ([PRIMARY], [PRIMARY], [PRIMARY]);


﻿CREATE PARTITION FUNCTION [MSAppServerPF_ASWcfEventsTable](DATETIME2 (7))
    AS RANGE RIGHT
    FOR VALUES ('01/01/0001 00:00:00');

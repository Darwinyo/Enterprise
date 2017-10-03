CREATE TABLE [dbo].[TblUserDetails] (
    [UserDetailsId]    VARCHAR (36)  NOT NULL,
    [FirstName]        VARCHAR (200) NULL,
    [MiddleName]       VARCHAR (200) NULL,
    [LastName]         VARCHAR (200) NULL,
    [EmailMain]        VARCHAR (200) NULL,
    [EmailSecondary]   VARCHAR (200) NULL,
    [PhoneMain]        INT           NULL,
    [PhoneSecondary]   INT           NULL,
    [AddressMain]      VARCHAR (200) NULL,
    [AddressSecondary] VARCHAR (200) NULL,
    [AddressThird]     VARCHAR (200) NULL,
    CONSTRAINT [PK_Tbl_User_Details] PRIMARY KEY CLUSTERED ([UserDetailsId] ASC)
);


CREATE TABLE dbo.Fact
(
  FactId  INT           NOT NULL IDENTITY(1,1),
  Content NVARCHAR(200) NOT NULL,
  CONSTRAINT pkcFact PRIMARY KEY CLUSTERED (FactId)
)
GO

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Fact',                         @value=N'A random fact about something interesting.',                          @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Fact', @level2name=N'FactId',  @value=N'The identifier of the fact record.',                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Fact', @level2name=N'Content', @value=N'The content of the fact.',                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Fact', @level2name=N'pkcFact', @value=N'Defines the primary key for the Fact table using the FactId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO

CREATE TABLE dbo.Quote
(
  QuoteId INT           NOT NULL IDENTITY(1,1),
  Author  NVARCHAR(100) NOT NULL,
  Content NVARCHAR(300) NOT NULL,
  CONSTRAINT pkcQuote PRIMARY KEY CLUSTERED (QuoteId)
)
GO

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Quote',                          @value=N'A quote from someone famous or interesting.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Quote', @level2name=N'QuoteId',  @value=N'The identifier of the quote record.',         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Quote', @level2name=N'Author',   @value=N'The author of the quote.',                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Quote', @level2name=N'Content',  @value=N'The content of the quote.',                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
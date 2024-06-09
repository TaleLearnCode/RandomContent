CREATE TABLE dbo.QuoteCategory
(
  QuoteCategoryId INT NOT NULL IDENTITY(1,1),
  QuoteId         INT NOT NULL,
  CategoryId      INT NOT NULL,
  CONSTRAINT pkcQuoteCategory PRIMARY KEY (QuoteCategoryId),
  CONSTRAINT fkQuoteCategory_Quote FOREIGN KEY (QuoteId) REFERENCES dbo.Quote (QuoteId),
  CONSTRAINT fkQuoteCategory_QuoteCategory FOREIGN KEY (CategoryId) REFERENCES dbo.Category (CategoryId)
)
GO

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'QuoteCategory',                                               @value=N'Represents the relationship between a quote and a category.',                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'QuoteCategory', @level2name=N'QuoteCategoryId',               @value=N'The identifier of the quote category record.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'QuoteCategory', @level2name=N'QuoteId',                       @value=N'The identifier of the quote record.',                                                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'QuoteCategory', @level2name=N'CategoryId',                    @value=N'The identifier of the category record.',                                                              @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'QuoteCategory', @level2name=N'pkcQuoteCategory',              @value=N'Defines the primary key for the QuoteCategory table using the QuoteCategoryId column.',               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'QuoteCategory', @level2name=N'fkQuoteCategory_Quote',         @value=N'Defines the relationship between the QuoteCategory and Quote tables using the QuoteId column.',       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'QuoteCategory', @level2name=N'fkQuoteCategory_QuoteCategory', @value=N'Defines the relationship between the QuoteCategory and Category tables using the CategoryId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
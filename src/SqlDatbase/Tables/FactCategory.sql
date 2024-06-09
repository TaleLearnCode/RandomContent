CREATE TABLE dbo.FactCategory
(
  FactCategoryId INT NOT NULL IDENTITY(1,1),
  FactId         INT NOT NULL,
  CategoryId     INT NOT NULL,
  CONSTRAINT pkcFactCategory PRIMARY KEY CLUSTERED (FactCategoryId),
  CONSTRAINT fkFactCategory_Fact         FOREIGN KEY (FactId)     REFERENCES dbo.Fact (FactId),
  CONSTRAINT fkFactCategory_FactCategory FOREIGN KEY (CategoryId) REFERENCES dbo.Category (CategoryId)
)
GO

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'FactCategory',                                             @value=N'Represents the relationship between a fact and a category.',                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'FactCategory', @level2name=N'FactCategoryId',              @value=N'The identifier of the fact category record.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'FactCategory', @level2name=N'FactId',                      @value=N'The identifier of the fact record.',                                                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'FactCategory', @level2name=N'CategoryId',                  @value=N'The identifier of the category record.',                                                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'FactCategory', @level2name=N'pkcFactCategory',             @value=N'Defines the primary key for the FactCategory table using the FactCategoryId column.',                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'FactCategory', @level2name=N'fkFactCategory_Fact',         @value=N'Defines the relationship between the FactCategory and Fact tables using the FactId column.',         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'FactCategory', @level2name=N'fkFactCategory_FactCategory', @value=N'Defines the relationship between the FactCategory and Category tables using the CategoryId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO